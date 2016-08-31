using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CollegeWebApplication.Controllers
{
    public class LoginController : Controller
    {
        List<UserInfo> users = new List<UserInfo>();

        public LoginController()
        {
            users.Add(new UserInfo { UserName = "gregor", Password = "password", Message = "Welcome back Gregor." });
            users.Add(new UserInfo { UserName = "joe", Password = "P@ssw0rd", Message = "Howdy Joe." });
            users.Add(new UserInfo { UserName = "gideon", Password = "giddyup", Message = "Sup Dawg?" });
            users.Add(new UserInfo { UserName = "jared", Password = "password", Message = "Thous hast entered with great success." });
        }
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // POST: Login/Create
        [HttpPost]
        public ActionResult Index(string userName, string password)
        {
            var user = users.FirstOrDefault(u => u.UserName == userName && u.Password == password);

            if (user != null)
            {
                ViewBag.Message = user.Message;
            }
            else
            {
                ViewBag.Message = "UserName or Password is invalid.";
            }
            return View();

        }

        private class UserInfo
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Message { get; set; }
        }

    }
}
