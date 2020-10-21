using scheduleCRM.Models;
using scheduleDbLayer.Repos.ModelRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace scheduleCRM.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string pass)
        {
            var user1 = new LoginModel(username, pass);
            var user2 = new UsersRepos().GetOne(username);

            var isValid = new LoginValidator(user1,user2).IsValid();

            if (isValid)
            {
                FormsAuthentication.SetAuthCookie(user1.Username, true);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = "Incorrect username or password";
            return View();
        }
    }
}