using System;
using TechTalk.SpecFlow;

namespace CollegeUnitTests.AcceptanceTests
{
    [Binding]
    public class AddCoursesSteps
    {
        [Given(@"I have added values to the college")]
        public void GivenIHaveAddedValuesToTheCollege(Table table)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the result courses should be displayed")]
        public void ThenTheResultCoursesShouldBeDisplayed(Table table)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
