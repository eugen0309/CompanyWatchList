using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using CompanyWatchListEF.Entities;
using CompanyWatchListCore.Models;
using CompanyWatchListCore.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Linq;

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
                Claim[] claims = GenerateClaims(user);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(claims),
                    Expires = DateTime.UtcNow.AddDays(1),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var tokenString = tokenHandler.WriteToken(token);
                var roles = user.UserRoles.Select(ur => ur.Role).Select(r => r.Name).ToList();
                return Ok(new
                {
                    user.Id,
                    user.UserName,
                    user.FirstName,
                    user.LastName,
                    roles,
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
        [Authorize(Roles = "Admin")]
        async public Task<IActionResult> Register([FromBody] RegistrationModel model)
        {
            var user = _mapper.Map<User>(model);
            try
            {
                var createdUser = await _userService.CreateAsync(user, model.Password, model.UserRoles);
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

        [HttpGet("{name}")]
        public IActionResult GetByName(string name)
        {
            try
            {
                var user = _userService.GetByUserName(name);
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
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(int id)
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


        private static Claim[] GenerateClaims(User user)
        {
            Claim[] claims = new Claim[user.UserRoles.Count + 1];
            var i = 0;
            claims[i] = new Claim(ClaimTypes.Name, user.UserName.ToString());
            foreach (var role in user.UserRoles)
            {
                i++;
                claims[i] = new Claim(ClaimTypes.Role, role.Role.Name);
            }

            return claims;
        }
    }
}