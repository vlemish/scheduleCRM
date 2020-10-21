using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scheduleCRM.Models
{
    public class LoginValidator : IValidator
    {
        public LoginModel User1 { get; set; }

        public LoginModel User2 { get; set; }

        public LoginValidator(LoginModel user1, LoginModel user2)
        {
            User1 = user1;
            User2 = user2;
        }

        public LoginValidator()
        {

        }

        public bool IsValid()
        {
            if (User1 != null || User2 != null)
            {
                if (User1.Equals((LoginModel)User2))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
