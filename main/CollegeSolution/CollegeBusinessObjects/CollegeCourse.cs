using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegeBusinessInterfaces;
using CollegeBusinessObjects.Exceptions;

namespace CollegeBusinessObjects
{
    public class CollegeCourse: ICollegeCourse
    {
        public string Name { get; private set; }
        public string PrerequisteCourseName { get; private set; }
        public ICollegeCourse Prerequisite { get; set; }
        public bool HasPrerequisite => Prerequisite != null;

        public CollegeCourse(string course)
        {
            var courseNames = course.Split(':');
            Name = courseNames[0].Trim();
            if (Name == "")
            {
                throw new InvalidCourseNameException(this);
            }

            if (courseNames.Length > 1)
            {
                var prerequisiteCourseName = courseNames[1].Trim();
                if (prerequisiteCourseName != "")
                {
                    PrerequisteCourseName = prerequisiteCourseName;
                }
            }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
