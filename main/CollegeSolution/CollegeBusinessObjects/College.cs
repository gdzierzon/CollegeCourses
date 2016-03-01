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
        public List<ICollegeCourse> Courses { get; set; }

        public void AddCourses(string[] courses)
        {
            
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
