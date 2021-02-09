﻿using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CompanyWatchList.Entities;
using CompanyWatchList.Models;
using CompanyWatchList.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace CompanyWatchList.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private readonly IConfiguration _config;
        private IMapper _mapper;
        private ILogger<UsersController> _logger;

        public UsersController(IUserService userService, IConfiguration config, IMapper mapper, ILogger<UsersController> logger)
        {
            _userService = userService;
            _config = config;
            _mapper = mapper;
            _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody]AuthenticationModel input)
        {
            try
            {
                var user = _userService.Authenticate(input.UserName, input.Password);
                if (user == null)
                    return BadRequest("Incorrect username or password");

                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_config["Secret"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);

                return Ok(new
                {
                    user.Id,
                    user.UserName,
                    user.FirstName,
                    user.LastName,
                    Token = tokenString
                });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
                        
        [HttpPost("register")]
        async public Task<IActionResult> Register([FromBody] RegistrationModel model)
        {
            var user = _mapper.Map<User>(model);
            try
            {
                await _userService.CreateAsync(user, model.Password);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
        

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var users = _userService.GetAll();
                var model = _mapper.Map<IList<UserModel>>(users);
                return Ok(model);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var user = _userService.GetById(id);
                if (user != null)
                {
                    var model = _mapper.Map<UserModel>(user);
                    return Ok(model);
                }
                else
                {
                    return NotFound("The required user was not found");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return NotFound();
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                if (await _userService.DeleteAsync(id))
                {
                    return Ok();
                }
                else
                {
                    return NotFound("Couldn't delete the specified user");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return BadRequest();
            }
        }
    }
}