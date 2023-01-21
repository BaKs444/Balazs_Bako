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

        public IWebElement AddButton => _driver.FindElement(By.CssSelector("button[class*='oxd-button--medium']"));
        public IWebElement AddNameTextField => _driver.FindElement(By.XPath("(//input)[2]"));
        public IWebElement SaveButton => _driver.FindElement(By.CssSelector("button[type='submit']"));
        public IWebElement AddCurrenciesButton => _driver.FindElement(By.XPath("//button[@type='button']//i[@class='oxd-icon bi-plus oxd-button-icon']"));
        public IWebElement SelectCurrencySlide => _driver.FindElement(By.XPath("//i[@class='oxd-icon bi-caret-down-fill oxd-select-text--arrow']"));
        public IWebElement SelectActualCurrency => _driver.FindElement(By.XPath("//div[@class='oxd-select-text-input']"));
        public IWebElement MinimumSallaryTextField => _driver.FindElement(By.XPath("(//input[@class='oxd-input oxd-input--active'])[3]"));
        public IWebElement MaximumSallaryTextField => _driver.FindElement(By.XPath("(//input[last()])[4]"));
        public IWebElement SaveSallaryButton => _driver.FindElement(By.XPath("(//button[@type='submit'])[2]"));
        public IWebElement MaximumSallaryField => _driver.FindElement(By.XPath("//div[contains(text(),'300000')]"));
        public IWebElement MinimumSallaryField => _driver.FindElement(By.XPath("//div[contains(text(),'250000')]"));
        public IWebElement SubmitDeleteButton => _driver.FindElement(By.XPath("//button[@class=\"oxd-button oxd-button--medium oxd-button--label-danger orangehrm-button-margin\"]"));
        public IWebElement JobButton => _driver.FindElement(By.XPath("//span[contains(text(),\"Job\")]"));
        public IWebElement PayGradesButton => _driver.FindElement(By.XPath("//a[contains(text(),\"Pay Grades\")]"));
        public IWebElement CancelButton => _driver.FindElement(By.XPath("(//div[@class='oxd-form-actions']//button[@class='oxd-button oxd-button--medium oxd-button--ghost'])[2]"));
        public IWebElement NoRecordsFound => _driver.FindElement(By.XPath("//*[@id=\"app\"]/div[1]/div[2]/div[2]/div[2]/div/div[2]/div/span"));
        public IList<IWebElement> Table => _driver.FindElements(By.ClassName("oxd-table-card"));
        public IList<IWebElement> NameFields => _driver.FindElements(By.XPath("//div[@class='data']"));
    }
}
