using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KungFu.Core.ApplictionService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Linq;

namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthentication _authService;
        private readonly ITokenService _tokenService;
        public TokenController(IAuthentication authService, ITokenService tokenService)
        {
            _authService = authService;
            _tokenService = tokenService;
        }


        // POST: api/Token
        [HttpPost]
        public IActionResult Refresh([FromBody] JObject data)
        {
            try
            {
                var principal = _authService.getExpiredPrincipal(data["token"].ToString()); //Check if token is formed correctly.
                var username = principal.Identity.Name; //Get username from expired token
                var savedRefreshToken = _tokenService.getRefreshToken(username); // Get current user refresh token. Preventing user from modifying the token in any way
                if (savedRefreshToken != data["refreshToken"].ToString()) //If not matching. Front end should disconnect user
                    throw new SecurityTokenException("Invalid refresh token");


                var newJwtToken = _authService.GenerateToken(principal.Claims); //Generate new token with same info as expired token. (IsAdmin and Username is contained)
                var newRefreshToken = _authService.GenerateRefreshToken(); // Generate new refresh token. Effectivly starting new seasion

                _tokenService.SaveRefreshToken(username, newRefreshToken); //Save new generated re

                return Ok(new
                {
                    Token = newJwtToken,
                    RefreshToken = newRefreshToken
                });
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
