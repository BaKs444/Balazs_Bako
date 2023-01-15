using OpenQA.Selenium;
using WebUI.Framework.Pages;

namespace WebUI.Framework.Contexts
{
    public class LoginContext
    {
        private readonly LoginPage _loginPage;
        public LoginContext(IWebDriver driver)
        {
            _loginPage = new LoginPage(driver);
        }

        public void Login(string username, string password)
        {
            _loginPage.userNameTextField.SendKeys(username);
            _loginPage.passwordTextField.SendKeys(password);
            _loginPage.logInButton.Click();
        }
    }
}
