using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeBusinessInterfaces
{
    public interface ICollegeCourse
    {
        string Name { get; set; }
        string PrerequisteCourseName { get; set; }
        ICollegeCourse Prerequisite { get; set; }
    }
}
