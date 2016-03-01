using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegeBusinessInterfaces;

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
