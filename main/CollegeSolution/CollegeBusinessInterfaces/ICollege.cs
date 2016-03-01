using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeBusinessInterfaces
{
    public interface ICollege
    {
        List<ICollegeCourse> Courses { get; }
        string Schedule { get; }
        void AddCourses(string[] courses);
    }
}
