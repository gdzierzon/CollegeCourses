using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using CollegeBusinessInterfaces;
using CollegeBusinessObjects;
using CollegeWebApplication.Controllers;
using NUnit.Framework;

namespace CollegeUnitTests.WebUITests
{
    [TestFixture]
    public class WebApiCollegeCoursesControllerTests
    {
        [Test]
        public void TestAddCoursesSuccess()
        {
            //arrange
            var coursesBuilder = new StringBuilder();
            coursesBuilder.Append("Intro to Fire\n");
            coursesBuilder.Append("Advanced Pyrotechnics: Intro to Fire");

            var expectedSchedule = "Intro to Fire, Advanced Pyrotechnics";

            var webApiController = new CollegeCourseController(new College());

            //act
            var result = webApiController.Post(coursesBuilder.ToString());

            //assert
            Assert.AreEqual(expectedSchedule, result);
        }

        [Test]
        public void TestAddCoursesWithBlankText()
        {
            //arrange
            var coursesList = " ";

            var expectedSchedule = "There are no courses in the schedule.";

            var webApiController = new CollegeCourseController(new College());

            //act
            var result = webApiController.Post(coursesList);

            //assert
            Assert.AreEqual(expectedSchedule, result);
        }

        [Test]
        public void TestAddCoursesWithExtraBlankLines()
        {
            //arrange
            var coursesBuilder = new StringBuilder();
            coursesBuilder.Append("Intro to Fire\n");
            coursesBuilder.Append("   \n");
            coursesBuilder.Append("Advanced Pyrotechnics: Intro to Fire\n");

            var expectedSchedule = "Intro to Fire, Advanced Pyrotechnics";

            var webApiController = new CollegeCourseController(new College());

            //act
            var result = webApiController.Post(coursesBuilder.ToString());

            //assert
            Assert.AreEqual(expectedSchedule, result);
        }

        [Test]
        public void TestAddCoursesWithCircularReference()
        {
            //arrange
            var coursesBuilder = new StringBuilder();
            coursesBuilder.Append("Intro to Fire: Advanced Pyrotechnics\n");
            coursesBuilder.Append("Advanced Pyrotechnics: Intro to Fire");

            var expectedSchedule = "'Advanced Pyrotechnics' has a prerequisite course with a cirular reference.";

            var webApiController = new CollegeCourseController(new College());

            //act
            var result = webApiController.Post(coursesBuilder.ToString());

            //assert
            Assert.AreEqual(expectedSchedule, result);
        }

        [Test]
        public void TestAddCoursesWithInavlidCourseName()
        {
            //arrange
            var coursesBuilder = new StringBuilder();
            coursesBuilder.Append("Intro to Fire\n");
            coursesBuilder.Append("Advanced Pyrotechnics: Intro to Fire: How to Build a Blaze");

            var expectedSchedule = "The course name \"Advanced Pyrotechnics: Intro to Fire: How to Build a Blaze\" is invalid.";

            var webApiController = new CollegeCourseController(new College());

            //act
            var result = webApiController.Post(coursesBuilder.ToString());

            //assert
            Assert.AreEqual(expectedSchedule, result);
        }
    }
}
