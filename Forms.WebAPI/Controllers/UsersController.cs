using Forms.Managers.Interfaces;
using Forms.Models;
using Forms.WebAPI.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Forms.WebAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersManager usersManager;
        private readonly AppSettings appSettings;

        public UsersController(IUsersManager usersManager, IOptions<AppSettings> appSettings)
        {
            this.usersManager = usersManager;
            this.appSettings = appSettings.Value;
        }

        [HttpGet("{id}")]
        public UserModel GetUserById(int id)
        {
            return usersManager.GetUserById(id);
        }

        [HttpGet]
        public IEnumerable<UserModel> GetUsers()
        {
            return usersManager.GetUsers();
        }

        [HttpPost]
        public long InserUser([FromBody] UserModel userModel)
        {
            return usersManager.InsertUser(userModel);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel loginModel)
        {
            var user = usersManager.Login(loginModel);
            if(user == null)
            {
                return BadRequest(new { message = "Login or password is incorrect" });
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.SecretKey);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);

            return Ok(user);
        }
    }
}