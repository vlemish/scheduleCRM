using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using scheduleDbCore.Models.DbModels;
using scheduleDbCore.Repos.ModelRepos;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ScheduleCRM_Web_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        // POST api/<UserController>
        [HttpPost("")]
        public object Post([FromBody] User user)
        {
            var _repo = new UsersRepos();
            var dbUser = _repo.GetOne(user.Username);
            if (dbUser != null)
            {
                if (dbUser.Password.Equals(user.Password))
                {
                    return new
                    {
                        username = dbUser.Username,
                        password = dbUser.Password
                    };
                }
            }

            return null;
        }
    }
}