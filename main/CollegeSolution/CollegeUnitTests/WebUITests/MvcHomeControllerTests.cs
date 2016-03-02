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
    public class MvcHomeControllerTests
    {
        [Test]
        public void TestAddCoursesSuccess()
        {
            //arrange
            var coursesBuilder = new StringBuilder();
            coursesBuilder.Append("Intro to Fire\n");
            coursesBuilder.Append("Advanced Pyrotechnics: Intro to Fire");

            var expectedSchedule = "Intro to Fire, Advanced Pyrotechnics";

            var mvcController = new HomeController(new College());

            //act
            var result = mvcController.Index(coursesBuilder.ToString()) as ViewResult;

            //assert
            Assert.NotNull(result,"result != null");

            var college = result.Model as ICollege;
            Assert.NotNull(college,"college != null");

            Assert.AreEqual(expectedSchedule, college.Schedule);
        }

        [Test]
        public void TestAddCoursesWithBlankText()
        {
            //arrange
            var coursesList = " ";

            var expectedSchedule = "There are no courses in the schedule.";

            var mvcController = new HomeController(new College());

            //act
            var result = mvcController.Index(coursesList) as ViewResult;

            //assert
            Assert.NotNull(result, "result != null");

            var college = result.Model as ICollege;
            Assert.NotNull(college, "college != null");

            Assert.AreEqual(expectedSchedule, college.Schedule);
        }

        [Test]
        public void TestAddCoursesWithExtraBlankLines()
        {
            //arrange
            var coursesBuilder = new StringBuilder();
            coursesBuilder.Append("Intro to Fire\n");
            coursesBuilder.Append("Advanced Pyrotechnics: Intro to Fire\n");

            var expectedSchedule = "Intro to Fire, Advanced Pyrotechnics";

            var mvcController = new HomeController(new College());

            //act
            var result = mvcController.Index(coursesBuilder.ToString()) as ViewResult;

            //assert
            Assert.NotNull(result, "result != null");

            var college = result.Model as ICollege;
            Assert.NotNull(college, "college != null");

            Assert.AreEqual(expectedSchedule, college.Schedule);
        }
    }
}
