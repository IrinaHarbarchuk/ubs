using System.Configuration;
using BoDi;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UbsWebFramework;

namespace UbsTest.StepDefinitions
{
    [Binding]
    public sealed class ScenarioHooks
    {
        private readonly IObjectContainer _container;

        public ScenarioHooks(IObjectContainer container)
        {
            _container = container;
        }

        [BeforeScenario]
        public void BeforeScenario()
        {
            var driver = WebDriverService.CreateWebDriver(ConfigurationManager.AppSettings["browserType"]);
            driver.Manage().Window.Maximize();
            _container.RegisterInstanceAs(driver);
        }

        [AfterScenario]
        public void AfterScenario()
        {
            IWebDriver driver = _container.Resolve<IWebDriver>();

            driver.Close();
            driver.Dispose();
        }
    }
}
