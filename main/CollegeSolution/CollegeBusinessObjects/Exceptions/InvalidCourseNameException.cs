using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegeBusinessInterfaces;

namespace CollegeBusinessObjects.Exceptions
{
    public class InvalidCourseNameException: Exception
    {

        public override string Message
        {
            get
            {
                return $"The course name \"{Course}\" is invalid.";

            }
        }

        public ICollegeCourse Course { get; set; }

        public InvalidCourseNameException(ICollegeCourse course)
        {
            Course = course;
        }
    }
}
