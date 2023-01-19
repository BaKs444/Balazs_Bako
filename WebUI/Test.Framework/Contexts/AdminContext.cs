using OpenQA.Selenium;
using WebUI.Framework.Pages;

namespace WebUI.Framework.Contexts
{
    public class AdminContext
    {
        private readonly AdminPage _adminPage;

        public AdminContext(IWebDriver driver)
        {
            _adminPage = new AdminPage(driver);
        }
        public void GoToPayGradesSite()
        {
            _adminPage.JobTopBarMenu.Click();
            _adminPage.PayGradesTopBarMenu.Click();
        }

    }
}
