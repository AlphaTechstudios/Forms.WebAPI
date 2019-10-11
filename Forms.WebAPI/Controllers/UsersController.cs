using Forms.Managers.Interfaces;
using Forms.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Forms.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersManager usersManager;

        public UsersController(IUsersManager usersManager)
        {
            this.usersManager = usersManager;
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
    }
}