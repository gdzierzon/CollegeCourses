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

        public override string Message
        {
            get
            {
                if (Course.Prerequisite != null)
                {
                    return $"{Course} has an invalid prerequisite course: ({Course.Prerequisite}).";
                }

                return $"'{Course}' has an invalid prerequisite course.";
            }
        }

        public ICollegeCourse Course { get; set; }

        public CircularPrerequisiteReferenceException(ICollegeCourse course)
        {
            Course = course;
        }
    }
}
