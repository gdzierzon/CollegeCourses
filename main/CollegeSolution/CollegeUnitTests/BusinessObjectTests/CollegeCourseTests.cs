using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CollegeBusinessInterfaces;
using CollegeBusinessObjects;
using CollegeBusinessObjects.Exceptions;
using NUnit.Framework;

namespace CollegeUnitTests.BusinessObjectTests
{
    [TestFixture]
    public class CollegeCourseTests
    {
        [Test]
        public void TestCreateCourseWithNoPrerequisite()
        {
            //arrange
            var courseName = "Advanced Pyrotechnics";
            //act
            var collegeCourse = new CollegeCourse(courseName);

            //assert
            Assert.AreEqual(courseName,collegeCourse.Name);
        }

        [Test]
        public void TestCreateCourseWithEmptyName()
        {
            //arrange
            var courseName = "   ";
            //act
            ICollegeCourse collegeCourse;

            //assert
            Assert.Throws(typeof(InvalidCourseNameException),
                () => { collegeCourse = new CollegeCourse(courseName); }
                );
        }

        [Test]
        public void TestCreateCouseWithPrerequisite()
        {

            //arrange
            var inputCourseName = "Advanced Pyrotechnics: Introduction to Fire";
            var courseName = "Advanced Pyrotechnics";
            var prerequisiteCourseName = "Introduction to Fire";
            //act
            var collegeCourse = new CollegeCourse(inputCourseName);

            //assert
            Assert.AreEqual(courseName, collegeCourse.Name);
            Assert.AreEqual(prerequisiteCourseName, collegeCourse.PrerequisteCourseName);
        }

        [Test]
        public void TestCreateCouseWithPrerequisiteEmptyName()
        {

            //arrange
            var inputCourseName = "Advanced Pyrotechnics:    ";
            var courseName = "Advanced Pyrotechnics";
            //act
            var collegeCourse = new CollegeCourse(inputCourseName);

            //assert
            Assert.AreEqual(courseName, collegeCourse.Name);
            Assert.AreEqual(null, collegeCourse.PrerequisteCourseName);
        }
    }
}
