using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebUI.Framework.Contexts;
using NUnit.Framework;

namespace WebUI.Test.Steps
{
    [Binding]
    public class AddNewRecordSteps
    {
        private readonly IWebDriver _driver;
        public readonly BaseContext _baseContext;
        public readonly AdminContext _adminContext;
        public readonly PayGradeContext _payGradeContext;

        public AddNewRecordSteps(ScenarioContext context)
        {
            _driver = context.Get<IWebDriver>("Driver");
            _baseContext = new BaseContext(_driver);
            _adminContext = new AdminContext(_driver);
            _payGradeContext = new PayGradeContext(_driver);
        }

        [When(@"I navigate to job and Pay Grades tab")]
        public void WhenINavigateToJobAndPayGradesTab()
        {
            _baseContext.GoToAdminPage();
            _adminContext.GoToPayGradesSite();
        }

        [When(@"I add a new entry with (.*)")]
        public void WhenIAddANewEntryWith(string randomName)
        {
            _payGradeContext.AddNewName(randomName);
        }

        [When(@"I assign (.*) minimum and (.*) sallary to it")]
        public void WhenIAssignMinimumAndSallaryToIt(string minimum, string maximum)
        {
            _payGradeContext.AddNewCurrency(minimum, maximum);
        }

        [Then(@"I see the changes in the Currencies block")]
        public void ThenISeeTheChangesInTheCurrenciesBlock()
        {
            bool newCurrencyAdded = _payGradeContext.CheckTheCurrencyTab();

            Assert.That(newCurrencyAdded.Equals(true));
        }



    }
}
