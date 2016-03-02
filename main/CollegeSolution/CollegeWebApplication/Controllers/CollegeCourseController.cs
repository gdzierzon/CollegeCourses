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

        // GET: api/CollegeCourse
        public string Get()
        {
            return "this is a GET test";
        }

        // GET: api/CollegeCourse/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/CollegeCourse
        public string Post([FromBody]string courses)
        {
            return "This is a POST test";
        }

        // PUT: api/CollegeCourse/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CollegeCourse/5
        public void Delete(int id)
        {
        }
    }
}
