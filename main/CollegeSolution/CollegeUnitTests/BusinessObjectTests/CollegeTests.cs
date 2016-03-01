using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegeBusinessObjects;
using CollegeBusinessObjects.Exceptions;
using NUnit.Framework;

namespace CollegeUnitTests.BusinessObjectTests
{
    [TestFixture]
    public class CollegeTests
    {
        [Test]
        public void TestAddCoursesWithNoPrerequisites()
        {
            //arrange
            var college = new College();
            string[] courseList = {"Intro to Fire", "Advanced Pyrotechnics"};

            //act
            college.AddCourses(courseList);

            //assert
            Assert.AreEqual(courseList.Length, college.Courses.Count);
        }

        [Test]
        public void TestAddCoursesWithInvalidName()
        {

            //arrange
            var college = new College();
            string[] courseList = {"Intro to Fire", "  "};

            //act
            //assert
            Assert.Throws<InvalidCourseNameException>(() => { college.AddCourses(courseList);});
            
        }


        [Test]
        public void TestAddCoursesWithValidPrerequisite()
        {

            //arrange
            var college = new College();
            var courseName1 = "Intro to Fire";
            var courseName2 = "Advanced Pyrotechnics";
            string[] courseList = { courseName1, $"{courseName2}: {courseName1}" };

            //act
            college.AddCourses(courseList);
            var course1 = college.Courses.SingleOrDefault(c => c.Name == courseName1);
            var course2 = college.Courses.SingleOrDefault(c => c.Name == courseName2);

            //assert
            Assert.AreEqual(course1, course2?.Prerequisite);


        }
    }
}
