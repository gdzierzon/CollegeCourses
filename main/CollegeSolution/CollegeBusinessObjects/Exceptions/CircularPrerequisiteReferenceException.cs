using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegeBusinessInterfaces;

namespace CollegeBusinessObjects.Exceptions
{
    public class CircularPrerequisiteReferenceException: Exception
    {

        public override string Message => $"'{Course}' has a prerequisite course with a cirular reference.";

        public ICollegeCourse Course { get; set; }

        public CircularPrerequisiteReferenceException(ICollegeCourse course)
        {
            Course = course;
        }
    }
}
