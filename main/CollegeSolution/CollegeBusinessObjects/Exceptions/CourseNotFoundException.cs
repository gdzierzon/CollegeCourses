using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace CollegeBusinessObjects.Exceptions
{
    public class CourseNotFoundException:Exception
    {
        public string CourseName { get; }

        public override string Message => $"'{CourseName}' was not found in the course list.";

        public CourseNotFoundException(string courseName)
        {
            CourseName = courseName;
        }
    }
}
