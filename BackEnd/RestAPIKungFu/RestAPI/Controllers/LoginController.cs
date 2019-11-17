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
        [Authorize(Roles = "Administrator")]
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

        // GET: api/Login/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Login
        [HttpPost]
        public IActionResult Post([FromBody] JObject data)
        {
            try
            {
                var validatedUser = _userService.ValidateUser(new Tuple<string, string>(data["Username"].ToString(), data["Password"].ToString()));

                return Ok(new
                {
                    Username = validatedUser.Item1,
                    Token = validatedUser.Item2,
                    IsAdmin = validatedUser.Item3
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        // PUT: api/Login/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
