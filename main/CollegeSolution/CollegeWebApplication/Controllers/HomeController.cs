using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CollegeBusinessInterfaces;

namespace CollegeWebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICollege _college;

        public HomeController(ICollege college)
        {
            _college = college;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_college);
        }

        [HttpPost]
        public ActionResult Index(string courses)
        {
            try
            {

                string[] courseList = courses.Trim().Split(new string[] { ",", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                _college.AddCourses(courseList);
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
            }

            return View(_college);
        }


    }
}
