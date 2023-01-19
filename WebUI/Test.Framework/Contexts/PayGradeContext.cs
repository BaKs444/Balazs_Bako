using OpenQA.Selenium;
using WebUI.Framework.Pages;

namespace WebUI.Framework.Contexts
{
    public class PayGradeContext
    {
        private readonly PayGradesPage _payGradesPage;
        private readonly IWebDriver _driver;

        public PayGradeContext(IWebDriver driver)
        {
            _payGradesPage = new PayGradesPage(driver);
            _driver = driver;
        }
        public void AddNewName(string name)
        {
            _payGradesPage.AddButton.Click();
            _payGradesPage.AddNameTextField.SendKeys(name);
            _payGradesPage.SaveButton.Click();
        }
        public void AddNewCurrency (string minimum, string maximum)
        {
            _payGradesPage.AddCurrenciesButton.Click();
            _payGradesPage.SelectCurrencySlide.Click();
            _payGradesPage.SelectActualCurrency.SendKeys("hhhhh\n");
            _payGradesPage.MinimumSallaryTextField.SendKeys(minimum);
            _payGradesPage.MaximumSallaryTextField.SendKeys(maximum);
            _payGradesPage.SaveSallaryButton.Click();
        }
        public void CancelAddNewCurrency(string minimum, string maximum)
        {
            _payGradesPage.AddCurrenciesButton.Click();
            _payGradesPage.SelectCurrencySlide.Click();
            _payGradesPage.SelectActualCurrency.SendKeys("hhhhh\n");
            _payGradesPage.MinimumSallaryTextField.SendKeys(minimum);
            _payGradesPage.MaximumSallaryTextField.SendKeys(maximum);
            _payGradesPage.CancelButton.Click();
        }
        public bool CheckTheCurrencyTab()
        {
            bool maximum = _payGradesPage.MaximumSallaryField != null;
            bool minimum = _payGradesPage.MinimumSallaryField != null;
            bool contains = (maximum == true && minimum == true) ? true : false;
            return contains;
        }
        public bool CheckTheCurrencyTabNotFound()
        {
            bool noRecordsFound = false;
            noRecordsFound = _payGradesPage.NoRecordsFound.Displayed == true;
            return noRecordsFound;
        }
        public void DeleteData()
        {
            _payGradesPage.JobButton.Click();
            _payGradesPage.PayGradesButton.Click();

            foreach (var item in _payGradesPage.Table)
            {
                if (item.Text.Contains("RandomName"))
                {
                    item.FindElement(By.ClassName("bi-trash")).Click();
                }
            }
            _payGradesPage.SubmitDeleteButton.Click();
        }
    }
}
