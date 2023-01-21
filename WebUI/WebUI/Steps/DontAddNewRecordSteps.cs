using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebUI.Framework.Contexts;

namespace WebUI.Test.Steps
{
    [Binding]
    public class DontAddNewRecordSteps
    {
        private readonly IWebDriver _driver;
        public readonly BaseContext _baseContext;
        public readonly AdminContext _adminContext;
        public readonly PayGradeContext _payGradeContext;

        public DontAddNewRecordSteps(ScenarioContext context)
        {
            _driver = context.Get<IWebDriver>("Driver");
            _baseContext = new BaseContext(_driver);
            _adminContext = new AdminContext(_driver);
            _payGradeContext = new PayGradeContext(_driver);
        }

        [When(@"I assign (.*) minimum and (.*) maximum sallary to it but click on cancel")]
        public void WhenIAssignMinimumAndMaximumSallaryToItButClickOnCancel(string minimum, string maximum)
        {
            _payGradeContext.CancelAddNewCurrency(minimum, maximum);
        }

        [Then(@"I don't see the changes in the Currencies block")]
        public void ThenIDontSeeTheChangesInTheCurrenciesBlock()
        {
            bool currencyNotFound = _payGradeContext.CheckTheCurrencyTabNotFound();
            _adminContext.GoToPayGradesSite();
            bool nameFound = _payGradeContext.CheckTheNameIsDisplayed();

            Assert.That(nameFound.Equals(true) && currencyNotFound.Equals(true));
        }


    }
}
