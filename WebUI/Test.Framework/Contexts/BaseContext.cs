using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using WebUI.Framework.Pages;

namespace WebUI.Framework.Contexts
{
    public class BaseContext
    {
        private readonly BasePage _basePage;
        private readonly IWebDriver _driver;
        public BaseContext(IWebDriver driver)
        {
            _basePage = new BasePage(driver);
            _driver = driver;
        }

        public bool IsPageLoaded()
        {
            var searchTextField = new WebDriverWait(_driver, TimeSpan.FromSeconds(2)).Until(d => _basePage.searchTextField);
            return _basePage.searchTextField != null && searchTextField.Displayed;
        }

        public void GoToAdminPage()
        {
            _basePage.adminMenuItem.Click();
        }
    }
}
