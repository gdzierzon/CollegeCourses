using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegeBusinessInterfaces;

namespace CollegeBusinessObjects
{
    public class CollegeCourse: ICollegeCourse
    {
        public string Name { get; set; }
        public string PrerequisteCourseName { get; set; }
        public ICollegeCourse Prerequisite { get; set; }

        public CollegeCourse(string course)
        {
            
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
