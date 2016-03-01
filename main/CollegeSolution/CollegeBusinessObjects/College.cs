using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegeBusinessInterfaces;
using CollegeBusinessObjects.Exceptions;

namespace CollegeBusinessObjects
{
    public class College: ICollege
    {
        public List<ICollegeCourse> Courses { get; private set; }

        public College()
        {
            Courses = new List<ICollegeCourse>();
        }

        public void AddCourses(string[] courses)
        {
            foreach (var course in courses)
            {
                var collegeCourse = new CollegeCourse(course);

                if (collegeCourse.PrerequisteCourseName != null)
                {
                    var prerequisite = Courses.SingleOrDefault(c => c.Name == collegeCourse.PrerequisteCourseName);
                    if (prerequisite == null)
                    {
                        throw new CourseNotFoundException(collegeCourse.PrerequisteCourseName);
                    }

                    collegeCourse.Prerequisite = prerequisite;
                }

                Courses.Add(collegeCourse);
            }
            
        }
        public void Validate()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "";//string.Join(", ", Courses);
        }
    }
}
