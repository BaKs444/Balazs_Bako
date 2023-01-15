using OpenQA.Selenium;
using TechTalk.SpecFlow;
using WebUI.Framework.Contexts;

namespace WebUI.Test.Steps
{
    public class DeleteDataSteps
    {
        private readonly IWebDriver _driver;
        private readonly PayGradeContext _payGradeContext;

        public DeleteDataSteps(ScenarioContext context)
        {
            _driver = context.Get<IWebDriver>("Driver");
            _payGradeContext = new PayGradeContext(_driver);
        }

        public void DeletData()
        {
            _payGradeContext.DeleteData();
        }

    }
}
