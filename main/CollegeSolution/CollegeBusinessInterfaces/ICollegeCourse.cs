using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CollegeBusinessInterfaces
{
    public interface ICollegeCourse
    {
        string Name { get; }
        string PrerequisteCourseName { get; }
        ICollegeCourse Prerequisite { get; set; }
    }
}
