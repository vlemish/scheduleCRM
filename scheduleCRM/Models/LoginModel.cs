using scheduleDbLayer.Models.DbModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.WebSockets;

namespace scheduleCRM.Models
{
    public class LoginModel
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public LoginModel(string username, string password)
        {
            Username = username;
            Password = password;
        }

        public LoginModel()
        {

        }

        public static explicit operator User(LoginModel loginModel)
        {
            if (loginModel == null)
            {
                return null;
            }

            return new User() { Username = loginModel.Username, Password = loginModel.Password };
        }

        public static implicit operator LoginModel(User user)
        {
            if (user == null)
            {
                return null;
            }

            return new LoginModel(user.Username, user.Password);
        }
    }
}