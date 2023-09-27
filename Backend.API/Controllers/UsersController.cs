using System;
using System.Collections.Generic;
using Backend.Data.Ef.Concrete;
using Backend.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Backend.API.Controllers
{
    [Authorize]
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("get")]
        public ActionResult<User> Get(User user)
        {
            return Ok(_userService.Get(user.Username, user.Password));
        }

        [HttpGet]
        [Route("getall")]
        public ActionResult<List<User>> Get()
        {
            return Ok(_userService.GetAll());
        }

        [HttpPut]
        [Route("add")]
        public ActionResult Add(User user)
        {
            return Ok(_userService.Add(user));
        }

        [HttpDelete]
        [Route("Delete")]
        public ActionResult Delete(int userId)
        {
            return Ok(_userService.Delete(userId));
        }
    }
}
