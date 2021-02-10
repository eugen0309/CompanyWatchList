using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
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
        private readonly ICompanyService _companyService;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
        private readonly ILogger<CompanyController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CompanyController
               (IUserService userService, 
                ICompanyService companyService, 
                IConfiguration config, 
                IMapper mapper, 
                ILogger<CompanyController> logger,
                IHttpContextAccessor httpContextAccessor)
        {
            _userService = userService;
            _companyService = companyService;
            _config = config;
            _mapper = mapper;
            _logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        [HttpGet]
        public ICollection<Company> GetWatchList()
        {
            var userName = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var userId = _userService.GetByUserName(userName);
            return _companyService.GetUserWatchlist(userId);
        }
    }
}