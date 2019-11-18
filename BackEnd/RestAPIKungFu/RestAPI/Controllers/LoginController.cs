using KungFu.Core.ApplictionService;
using KungFu.Entity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;

        public LoginController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/Login
        [Authorize(Roles = "Administrator, User")] // This method can be accessed by both Admin and user
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            try
            {
                return Ok(_userService.GetAllUsers());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Authorize] // This method can be accessed by anyone with a token
        // GET: api/Login/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Login
        [HttpPost] //This method doesnt require token
        public IActionResult Post([FromBody] JObject data)
        {
            try
            {
                var validatedUser = _userService.ValidateUser(new Tuple<string, string>(data["username"].ToString(), data["password"].ToString()));

                return Ok(new
                {
                    Token = validatedUser.Item1,
                    RefreshToken = validatedUser.Item2
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}