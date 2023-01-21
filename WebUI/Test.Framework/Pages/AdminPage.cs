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
        public IWebElement JobTopBarMenu => _driver.FindElement(By.XPath("//span[contains(text(),\"Job\")]"));
        public IWebElement PayGradesTopBarMenu => _driver.FindElement(By.XPath("//a[contains(text(),\"Pay Grades\")]"));
    }
}
