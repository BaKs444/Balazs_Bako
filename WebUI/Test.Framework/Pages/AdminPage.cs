using OpenQA.Selenium;

namespace WebUI.Framework.Pages
{
    public class AdminPage
    {
        private readonly IWebDriver _driver;
        public AdminPage(IWebDriver driver)
        {
            _driver = driver;
        }
        public IWebElement JobTopBarMenu => _driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[1]/header/div[2]/nav/ul/li[2]/span/i"));
        public IWebElement PayGradesTopBarMenu => _driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-navigation > header > div.oxd-topbar-body > nav > ul > li.--active.oxd-topbar-body-nav-tab.--parent > ul > li:nth-child(2) > a"));
    }
}
