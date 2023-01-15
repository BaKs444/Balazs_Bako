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
        private const string minimumSallary = "250000";
        private const string maximumSallary = "300000";

        public DontAddNewRecordSteps(ScenarioContext context)
        {
            _driver = context.Get<IWebDriver>("Driver");
            _baseContext = new BaseContext(_driver);
            _adminContext = new AdminContext(_driver);
            _payGradeContext = new PayGradeContext(_driver);
        }

        [When(@"I assign sallary to it but click on cancel")]
        public void WhenIAssignSallaryToItButClickOnCancel()
        {
            _payGradeContext.CancelAddNewCurrency(minimumSallary, maximumSallary);
        }

        [Then(@"I don't see the changes in the Currencies block")]
        public void ThenIDontSeeTheChangesInTheCurrenciesBlock()
        {
            bool currencyNotFound = _payGradeContext.CheckTheCurrencyTabNotFound();
            Assert.That(currencyNotFound.Equals(true));
        }


    }
}
