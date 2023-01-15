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
        private const string payGradeName = "RandomName";
        private const string minimumSallary = "250000";
        private const string maximumSallary = "300000";

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

        [When(@"I add a new entry with random name")]
        public void WhenIAddANewEntryWithRandomName()
        {
            _payGradeContext.AddNewName(payGradeName);
        }

        [When(@"I assign sallary to it")]
        public void WhenIAssignSallaryToIt()
        {
            _payGradeContext.AddNewCurrency(minimumSallary, maximumSallary);
        }

        [Then(@"I see the changes in the Currencies block")]
        public void ThenISeeTheChangesInTheCurrenciesBlock()
        {
            bool newCurrencyAdded = _payGradeContext.CheckTheCurrencyTab();

            Assert.That(newCurrencyAdded.Equals(true));
        }



    }
}
