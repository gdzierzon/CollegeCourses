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
    }
}
