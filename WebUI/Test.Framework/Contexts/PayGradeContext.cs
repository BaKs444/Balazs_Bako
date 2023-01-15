using OpenQA.Selenium;
using WebUI.Framework.Pages;

namespace WebUI.Framework.Contexts
{
    public class PayGradeContext
    {
        private readonly PayGradesPage _payGradesPage;

        public PayGradeContext(IWebDriver driver)
        {
            _payGradesPage = new PayGradesPage(driver);
        }
        public void AddNewName(string name)
        {
            _payGradesPage.addButton.Click();
            _payGradesPage.addNameTextField.SendKeys(name);
            _payGradesPage.saveButton.Click();
        }
        public void AddNewCurrency (string minimum, string maximum)
        {
            _payGradesPage.addCurrenciesButton.Click();
            _payGradesPage.selectCurrencySlide.Click();
            _payGradesPage.selectActualCurrency.SendKeys("hhhhh\n");
            _payGradesPage.minimumSallaryTextField.SendKeys(minimum);
            _payGradesPage.maximumSallaryTextField.SendKeys(maximum);
            _payGradesPage.saveSallaryButton.Click();
        }
        public void CancelAddNewCurrency(string minimum, string maximum)
        {
            _payGradesPage.addCurrenciesButton.Click();
            _payGradesPage.selectCurrencySlide.Click();
            _payGradesPage.selectActualCurrency.SendKeys("hhhhh\n");
            _payGradesPage.minimumSallaryTextField.SendKeys(minimum);
            _payGradesPage.maximumSallaryTextField.SendKeys(maximum);
            _payGradesPage.cancelButton.Click();
        }
        public bool CheckTheCurrencyTab()
        {
            bool maximum = _payGradesPage.maximumSallaryField != null;
            bool minimum = _payGradesPage.minimumSallaryField != null;
            bool contains = (maximum == true && minimum == true) ? true : false;
            return contains;
        }
        public bool CheckTheCurrencyTabNotFound()
        {
            bool noRecordsFound = false;
            noRecordsFound = _payGradesPage.noRecordsFound.Displayed == true;
            return noRecordsFound;
        }
        public void DeleteData()
        {
            _payGradesPage.jobButton.Click();
            _payGradesPage.payGradesButton.Click();
            _payGradesPage.deleteButton.Click();
            _payGradesPage.submitDeleteButton.Click();
        }
    }
}
