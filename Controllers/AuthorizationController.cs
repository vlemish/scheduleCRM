using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using scheduleDbCore.Repos.ModelRepos;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using WebAPI_scheduleCRM.Models;

namespace WebAPI_scheduleCRM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        public IActionResult Login([FromBody] LoginModel model)
        {
            var user = new UsersRepos().GetOne(model.Username);

            if (user != null && user.Password.Equals(model.Password))
            {

                IdentityOptions _options = new IdentityOptions();

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                    {
                    new Claim("UserId", user.Id.ToString()),
                    new Claim("Identity", user.Identity.ToString())
                    }),
                    Expires = DateTime.Now.AddMinutes(30),
                };

                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);

                return Ok(new { token = token, identity = user.Identity.ToString() });
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
