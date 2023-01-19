using OpenQA.Selenium;

namespace WebUI.Framework.Pages
{
    public class BasePage
    {
        private readonly IWebDriver _driver;
        public BasePage(IWebDriver driver)
        {
            _driver = driver;

        }
        public IWebElement SearchTextField => _driver.FindElement(By.CssSelector(".oxd-input"));
        public IWebElement AdminMenuItem => _driver.FindElement(By.CssSelector("span[class*= \"oxd-main-menu-item--name\"]"));
    }
}
