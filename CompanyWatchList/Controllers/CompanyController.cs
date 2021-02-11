using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using CompanyWatchListCore.Models;
using CompanyWatchListCore.Services;
using CompanyWatchListEF.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CompanyWatchList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompanyController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IWatchlistService _watchlistService;
        private readonly ICompanyService _companyService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly ILogger<CompanyController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CompanyController
               (IUserService userService, 
                IWatchlistService watchlistService, 
                ICompanyService companyService,
                IConfiguration config, 
                IMapper mapper, 
                ILogger<CompanyController> logger,
                IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _watchlistService = watchlistService;
            _companyService = companyService;
            _config = config;
            _mapper = mapper;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]        
        public IActionResult GetWatchList()
        {
            try
            {
                var userName = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
                var user = _userService.GetByUserName(userName);
                IEnumerable<Company> result = _watchlistService.GetUserWatchlist(user.Id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpGet("search/{keywords}")]
        public async Task<IActionResult> Search(string keywords)
        {
            try
            {
                IEnumerable<CompanySearchResultModel> result = await _companyService.SearchCompanies(keywords);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpPost("follow")]
        public async Task<IActionResult> AddCompanyToWatchList([FromBody] CompanySearchResultModel companySearchResult)
        {
            try
            {
                var userName = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
                var user = _userService.GetByUserName(userName);
                var company = _mapper.Map<Company>(companySearchResult);
                await _watchlistService.AddCompanyToWatchListAsync(user.Id, company.Name, company.Symbol);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

        [HttpDelete("unfollow/{id:int}")]
        public async Task<IActionResult> RemoveCompanyFromWatchlistAsync(int id)
        {
            try
            {
                var userName = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value;
                var user = _userService.GetByUserName(userName);
                await _watchlistService.RemoveCompanyFromWatchlistAsync(user.Id, id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }

    }
}