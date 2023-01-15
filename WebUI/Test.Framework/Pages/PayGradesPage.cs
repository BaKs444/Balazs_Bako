using OpenQA.Selenium;

namespace WebUI.Framework.Pages
{
    public class PayGradesPage
    {
        private readonly IWebDriver _driver;
        public PayGradesPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement addButton => _driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > div.orangehrm-header-container > div > button > i"));
        public IWebElement addNameTextField => _driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div.oxd-form-row > div > div > div > div:nth-child(2) > input"));
        public IWebElement saveButton => _driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div > div > form > div.oxd-form-actions > button.oxd-button.oxd-button--medium.oxd-button--secondary.orangehrm-left-space"));
        public IWebElement addCurrenciesButton => _driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div:nth-child(2) > div > div.orangehrm-header-container > div > button > i"));
        public IWebElement selectCurrencySlide => _driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div[2]/form/div[1]/div/div/div/div[2]/div/div/div[2]/i"));
        public IWebElement selectActualCurrency => _driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div[2]/form/div[1]/div/div/div/div[2]/div/div/div[1]"));
        public IWebElement minimumSallaryTextField => _driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div.orangehrm-card-container > form > div:nth-child(2) > div > div:nth-child(1) > div > div:nth-child(2) > input"));
        public IWebElement maximumSallaryTextField => _driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div.orangehrm-card-container > form > div:nth-child(2) > div > div:nth-child(2) > div > div:nth-child(2) > input"));
        public IWebElement saveSallaryButton => _driver.FindElement(By.CssSelector("#app > div.oxd-layout > div.oxd-layout-container > div.oxd-layout-context > div.orangehrm-card-container > form > div.oxd-form-actions > button.oxd-button.oxd-button--medium.oxd-button--secondary.orangehrm-left-space"));
        public IWebElement maximumSallaryField => _driver.FindElement(By.XPath("//div[contains(text(), \"300000\")]"));
        public IWebElement minimumSallaryField => _driver.FindElement(By.XPath("//div[contains(text(), \"250000\")]"));
        public IWebElement deleteButton => _driver.FindElement(By.XPath("(//i[@class=\"oxd-icon bi-trash\"])[3]"));
        public IWebElement submitDeleteButton => _driver.FindElement(By.XPath("//button[@class=\"oxd-button oxd-button--medium oxd-button--label-danger orangehrm-button-margin\"]"));
        public IWebElement jobButton => _driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[1]/header/div[2]/nav/ul/li[2]/span/i"));
        public IWebElement payGradesButton => _driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[1]/header/div[2]/nav/ul/li[2]/ul/li[2]/a"));
        public IWebElement cancelButton => _driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div[2]/form/div[3]/button[1]"));
        public IWebElement noRecordsFound => _driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div[2]/div/div[2]/div/span"));
    }
}
