using OpenQA.Selenium;

namespace WebUI.Framework.Pages
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;

        }
        public IWebElement userNameTextField => _driver.FindElement(By.CssSelector("input[name=username]"));
        public IWebElement passwordTextField => _driver.FindElement(By.CssSelector("input[name=password]"));
        public IWebElement logInButton => _driver.FindElement(By.CssSelector("button[class*=login]"));
    }
}
