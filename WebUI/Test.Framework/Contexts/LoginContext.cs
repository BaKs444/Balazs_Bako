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
            _loginPage.UserNameTextField.SendKeys(username);
            _loginPage.PasswordTextField.SendKeys(password);
            _loginPage.LogInButton.Click();
        }
    }
}
