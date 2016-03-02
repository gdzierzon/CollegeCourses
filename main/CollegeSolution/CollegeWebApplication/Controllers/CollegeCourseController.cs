using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CollegeBusinessInterfaces;

namespace CollegeWebApplication.Controllers
{
    public class CollegeCourseController : ApiController
    {
        private readonly ICollege _college;

        public CollegeCourseController(ICollege college)
        {
            _college = college;
        }

       
        // POST: api/CollegeCourse
        public string Post([FromBody]string courses)
        {
            try
            {
                string[] courseList = courses.Trim().Split(new string[] { ",", "\n" }, StringSplitOptions.RemoveEmptyEntries);
                _college.AddCourses(courseList);

                return _college.Schedule;
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        
    }
}
