using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebUI.Framework.Contexts;

namespace WebUI.Test.Steps
{
    [Binding]
    public class DeleteDataSteps
    {
        private readonly IWebDriver _driver;
        private readonly PayGradeContext _payGradeContext;
        public readonly BaseContext _baseContext;
        public readonly AdminContext _adminContext;

        public DeleteDataSteps(ScenarioContext context)
        {
            _driver = context.Get<IWebDriver>("Driver");
            _payGradeContext = new PayGradeContext(_driver);
            _adminContext = new AdminContext(_driver);
            _baseContext= new BaseContext(_driver);
        }
        [Given(@"I navigate to job and Pay Grades tab")]
        public void GivenINavigateToJobAndPayGradesTab()
        {
            _baseContext.GoToAdminPage();
            _adminContext.GoToPayGradesSite();
        }

        [When(@"I delete added data")]
        public void WhenIDeleteAddedData()
        {
            _payGradeContext.DeleteData();
        }
        [Then(@"I check that the data is removed")]
        public void ThenICheckThatTheDataIsRemoved()
        {
           bool nameNotDisplayed = _payGradeContext.CheckTheNameIsDisplayed();
            Assert.That(nameNotDisplayed, Is.False);
        }



        public void DeletData()
        {
            _payGradeContext.DeleteData();
        }

    }
}
