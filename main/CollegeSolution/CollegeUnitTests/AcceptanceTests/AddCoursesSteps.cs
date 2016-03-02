using System;
using System.Web.Mvc;
using CollegeBusinessInterfaces;
using CollegeBusinessObjects;
using CollegeWebApplication.Controllers;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace CollegeUnitTests.AcceptanceTests
{
    [Binding]
    public class AddCoursesSteps
    {
        [Given(@"I am adding courses to a college")]
        public void GivenIAmAddingCoursesToACollege()
        {
        }
        
        [Then(@"the courseList list should display schedule")]
        public void ThenTheCourseListListShouldDisplaySchedule(Table table)
        {
            foreach (var row in table.Rows)
            {
                //arrange
                string courseList = row["courseList"].Replace(",","\n");
                string expectedSchedule = row["schedule"];
                string actualResult;
                
                var mvcController = new HomeController(new College());

                //act
                var result = mvcController.Index(courseList) as ViewResult;

                //assert
                Assert.NotNull(result,"result != null");

                var college = result.Model as ICollege;
                Assert.NotNull(college,"college != null");

                actualResult = result.ViewBag.ErrorMessage ?? college.Schedule;
                Assert.AreEqual(expectedSchedule,actualResult);

            }
        }
    }
}
