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
        private List<ICollegeCourse> OrderedCourses { get; set; } 

        public string Schedule
        {
            get
            {
                if (Courses == null || Courses.Count == 0) return "There are no courses in the schedule.";

                OrderedCourses.Clear();
                var coursesToAdd = Courses.Where(c => !c.HasPrerequisite).OrderBy(c=>c.Name).ToList();
                SortCourses(coursesToAdd);

                return string.Join(", ", OrderedCourses); 
                
            }
        }

        private void SortCourses(List<ICollegeCourse> coursesToAdd)
        {
            foreach (var course in coursesToAdd)
            {
                if (!OrderedCourses.Exists(c => c.Name == course.Name))
                {
                    OrderedCourses.Add(course);
                }

                var dependentCourses = Courses.Where(c => c.Prerequisite == course).ToList();
                SortCourses(dependentCourses);
            }
        }


        public College()
        {
            Courses = new List<ICollegeCourse>();
            PrerequisitesCourseList = new List<ICollegeCourse>();
            OrderedCourses = new List<ICollegeCourse>();
        }

        public void AddCourses(string[] courses)
        {
            foreach (var course in courses)
            {
                //do not try to add blank courses
                if(course.Trim() == "") continue;

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
                //clear prerequisites before recursively checking for circular reference
                PrerequisitesCourseList.Clear();
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
