using Allure.Commons;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;
using WebUI.Framework.Contexts;

namespace WebUI.Test
{
    [Binding]
    public class Hooks
    {
        private readonly IWebDriver _driver;
        private readonly ScenarioContext _scenarioContext;
        public readonly PayGradeContext _payGradeContext;
        public static AllureLifecycle allure = AllureLifecycle.Instance;

        public Hooks(ScenarioContext context)
        {
            _driver = new ChromeDriver();
            _scenarioContext = context;
            _payGradeContext = new PayGradeContext(_driver);
        }

        [BeforeTestRun]

        public static void BeforeTestRun()
        {
            allure.CleanupResultDirectory();
        }

        [BeforeScenario]

        public void StartDriver()
        {
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            _scenarioContext["Driver"] = _driver;
            _driver.Manage().Window.Maximize();

        }

        [AfterScenario]

        public void StopDriverAndDeleteData()
        {
            _payGradeContext.DeleteData();
            _driver.Close();
            _driver.Dispose();
        }
    }
}
