using OpenQA.Selenium;

namespace WebUI.Framework.Pages
{
    public class PayGradesPage
    {
        private IWebDriver _driver;
        public PayGradesPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement AddButton => _driver.FindElement(By.CssSelector("button[class*=\"oxd-button--medium\"]"));
        public IWebElement AddNameTextField => _driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div.oxd-form-row > div > div > div > div:nth-child(2) > input"));
        public IWebElement SaveButton => _driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div.oxd-form-actions > button.oxd-button.oxd-button--medium.oxd-button--secondary.orangehrm-left-space"));
        public IWebElement AddCurrenciesButton => _driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div:nth-child(2) > div > div.orangehrm-header-container > div > button > i"));
        public IWebElement SelectCurrencySlide => _driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div[2]/form/div[1]/div/div/div/div[2]/div/div/div[2]/i"));
        public IWebElement SelectActualCurrency => _driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div[2]/form/div[1]/div/div/div/div[2]/div/div/div[1]"));
        public IWebElement MinimumSallaryTextField => _driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div.orangehrm-card-container > form > div:nth-child(2) > div > div:nth-child(1) > div > div:nth-child(2) > input"));
        public IWebElement MaximumSallaryTextField => _driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div.orangehrm-card-container > form > div:nth-child(2) > div > div:nth-child(2) > div > div:nth-child(2) > input"));
        public IWebElement SaveSallaryButton => _driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div.orangehrm-card-container > form > div.oxd-form-actions > button.oxd-button.oxd-button--medium.oxd-button--secondary.orangehrm-left-space"));
        public IWebElement MaximumSallaryField => _driver.FindElement(By.XPath("//div[contains(text(), \"300000\")]"));
        public IWebElement MinimumSallaryField => _driver.FindElement(By.XPath("//div[contains(text(), \"250000\")]"));
        public IWebElement SubmitDeleteButton => _driver.FindElement(By.XPath("//button[@class=\"oxd-button oxd-button--medium oxd-button--label-danger orangehrm-button-margin\"]"));
        public IWebElement JobButton => _driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[1]/header/div[2]/nav/ul/li[2]/span/i"));
        public IWebElement PayGradesButton => _driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[1]/header/div[2]/nav/ul/li[2]/ul/li[2]/a"));
        public IWebElement CancelButton => _driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div[2]/form/div[3]/button[1]"));
        public IWebElement NoRecordsFound => _driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div[2]/div/div[2]/div/span"));
        public IList<IWebElement> Table => _driver.FindElements(By.ClassName("oxd-table-card"));
    }
}
