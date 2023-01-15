using TechTalk.SpecFlow;
using OpenQA.Selenium;
using WebUI.Framework.Contexts;

namespace WebUI.Test.Steps
{
    [Binding]
    public class LoginSteps
    {
        private readonly IWebDriver _driver;

        public readonly LoginContext _loginContext;

        public readonly BaseContext _baseContext;

        private const string userName = "Admin";
        private const string userPassword = "admin123";

        public LoginSteps(ScenarioContext context)
        {
            _driver = context.Get<IWebDriver>("Driver");
            _loginContext = new LoginContext(_driver);
            _baseContext = new BaseContext(_driver);
        }

        [When(@"I log in as admin user")]
        public void WhenILogInAsUser()
        {
            _loginContext.Login(userName, userPassword);
        }
    }

}
