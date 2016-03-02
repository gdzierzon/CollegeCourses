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
        public void TestAddCoursesWithBlankNames()
        {

            //arrange
            var college = new College();
            var courseName1 = "Intro to Fire";
            var courseName2 = "   ";
            string[] courseList = { courseName1, courseName2 };

            //act
            college.AddCourses(courseList);

            //assert
            Assert.AreEqual(courseName1, college.Schedule);
            
        }

        [Test]
        public void TestAddCoursesWithPrerequistesUnsorted()
        {

            //arrange
            var college = new College();
            var courseName1 = "Intro to Fire";
            var courseName2 = "Advanced Pyrotechnics";
            string[] courseList = { $"{courseName2}: {courseName1}", courseName1 };

            //act
            college.AddCourses(courseList);
            var course1 = college.Courses.SingleOrDefault(c => c.Name == courseName1);
            var course2 = college.Courses.SingleOrDefault(c => c.Name == courseName2);

            //assert
            Assert.AreEqual(course1, course2?.Prerequisite);


        }

        [Test]
        public void TestAddCoursesWithInvalidPrerequisiteName()
        {

            //arrange
            var college = new College();
            string[] courseList = { "Intro to Fire", "Advanced Pyrotechnics: Introduction to Fire" };

            //act
            //assert
            Assert.Throws<CourseNotFoundException>(() => { college.AddCourses(courseList); });

        }

        [Test]
        public void TestAddCoursesWithValidPrerequisiteName()
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

        [Test]
        public void TestAddCoursesWithCircularReference()
        {

            //arrange
            var college = new College();
            var courseName1 = "Intro to Fire";
            var courseName2 = "Advanced Pyrotechnics";
            string[] courseList = { $"{courseName1}: {courseName2}", $"{courseName2}: {courseName1}" };

            //act
            //assert
            Assert.Throws<CircularPrerequisiteReferenceException>(() => { college.AddCourses(courseList); });
            
        }

        [Test]
        public void TestDisplayScheduleCoursesAddedInOrder()
        {

            //arrange
            var college = new College();
            var courseName1 = "Intro to Fire";
            var courseName2 = "Advanced Pyrotechnics";
            string[] courseList = { courseName1, $"{courseName2}: {courseName1}" };

            var expectedSchedule = $"{courseName1}, {courseName2}";

            //act
            college.AddCourses(courseList);

            //assert
            Assert.AreEqual(expectedSchedule, college.Schedule);
        }

        [Test]
        public void TestDisplayScheduleCoursesAddedOutOfOrder()
        {

            //arrange
            var college = new College();
            var courseName1 = "Intro to Fire";
            var courseName2 = "Advanced Pyrotechnics";
            string[] courseList = { $"{courseName2}: {courseName1}", courseName1 };

            var expectedSchedule = $"{courseName1}, {courseName2}";

            //act
            college.AddCourses(courseList);

            //assert
            Assert.AreEqual(expectedSchedule, college.Schedule);
        }


        [Test]
        public void TestDisplayScheduleWithMultipleCourses()
        {

            //arrange
            var college = new College();
            var courseName1 = "Introduction to Paper Airplanes";
            var courseName2 = "Advanced Throwing Techniques";
            var courseName3 = "Intro to Fire";
            var courseName4 = "Advanced Pyrotechnics";
            string[] courseList = { $"{courseName2}: {courseName1}", courseName1, $"{courseName4}: {courseName3}", courseName3 };

            var expectedSchedule = $"{courseName3}, {courseName4}, {courseName1}, {courseName2}";

            //act
            college.AddCourses(courseList);

            //assert
            Assert.AreEqual(expectedSchedule, college.Schedule);
        }
    }
}
