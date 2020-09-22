using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Models;
using Microsoft.AspNetCore.Mvc;
using Services.ConvertionModels;
using Services.IServices;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace LaptopBE.Controllers
{
    [Route("api/v1/users")]
    public class UsersController : Controller
    {
        private readonly IUserService userService;
        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }
        //POST api/v1/users/login
        [HttpPost("signin")]
        public IActionResult Login(string userName, string password)
        {
            bool result = userService.Login(userName, password);
            if (!result) return BadRequest("Login failed");
            return Ok();
        }
        //POST api/v1/users/register
        [HttpPost("signup")]
        public IActionResult Register(RegisterModel registerModel)
        {
            userService.Register(registerModel);
            userService.Save();
            return Ok();
        }
        // POST api/v1/users/{username}
        [HttpGet("{username}")]
        public IActionResult GetUser(string username)
        {
            User user = userService.GetUser(username);
            if (user == null) return Content("User not found");
            return Ok(user);
        }

        //PUT api/v1/users
        [HttpPut]
        public IActionResult UpdateUser(User user)
        {
            userService.UpdateUser(user);
            return Ok(user);
        }
    }
}
