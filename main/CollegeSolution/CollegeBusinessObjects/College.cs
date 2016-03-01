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
        private List<ICollegeCourse> PrerequisitesCourseList { get; set; }

        public string Schedule
        {
            get { return ""; }
        }

        public College()
        {
            Courses = new List<ICollegeCourse>();
            PrerequisitesCourseList = new List<ICollegeCourse>();
        }

        public void AddCourses(string[] courses)
        {
            foreach (var course in courses)
            {
                var collegeCourse = new CollegeCourse(course);
                
                Courses.Add(collegeCourse);
            }

            MapCoursePrerequisites();
            ValidateCourses();
        }

        private void MapCoursePrerequisites()
        {
            foreach (var collegeCourse in Courses)
            {
                if (collegeCourse.PrerequisteCourseName != null)
                {
                    var prerequisite = Courses.SingleOrDefault(c => c.Name == collegeCourse.PrerequisteCourseName);
                    if (prerequisite == null)
                    {
                        throw new CourseNotFoundException(collegeCourse.PrerequisteCourseName);
                    }

                    collegeCourse.Prerequisite = prerequisite;
                }
            }
        }

        private void ValidateCourses()
        {
            foreach (var course in Courses)
            {
                CheckForPrerequisiteCourse(course);
            }
        }

        private void CheckForPrerequisiteCourse(ICollegeCourse course)
        {
            if (course.HasPrerequisite)
            {
                var exists = PrerequisitesCourseList.Exists(c => c == course.Prerequisite);
                if (exists)
                {
                    throw new CircularPrerequisiteReferenceException(course);
                }

                PrerequisitesCourseList.Add(course);
                CheckForPrerequisiteCourse(course.Prerequisite);
            }
        }

       
    }
}
