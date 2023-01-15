using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace WebUI.Test.Steps
{
    [Binding]
    public class NavigationSteps
    {
        private readonly IWebDriver _driver;

        public NavigationSteps(ScenarioContext context)
        {
            _driver = context.Get<IWebDriver>("Driver");
        }

        [Given(@"I navigate to webpage")]
        public void GivenINavigateToWebpage()
        {
            _driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/");
        }

    }
}
