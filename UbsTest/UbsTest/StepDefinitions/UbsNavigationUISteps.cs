using System.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using UbsWebFramework.Pages;

namespace UbsTest.StepDefinitions
{
    [Binding]
    public class UbsNavigationUISteps
    {
        public IWebDriver Driver;

        public UbsNavigationUISteps(IWebDriver driver)
        {
            Driver = driver;
        }

        [Given(@"I have opened UBS website")]
        public void GivenIHaveOpenedUBSWebsite()
        {
            var ubsPage = new UbsBasePage(Driver);
            ubsPage.OpenPage(ConfigurationManager.AppSettings["baseUrl"]);          
            ScenarioContext.Current.Set(ubsPage, ContextConstants.UbsPage);
        }
        
        [When(@"I click on '(.*)' menu item under '(.*)' menu tab")]
        public void WhenIClickOnMenuItemUnderMenuTab(string menuItem, string menuTab)
        {
            var page = ScenarioContext.Current.Get<UbsBasePage>(ContextConstants.UbsPage).GetContent<UbsBasePage>();
            page.SelectMenuItemFromTab(menuTab, menuItem);
        }
        
        [Then(@"I can see that page with title '(.*)' is displayed")]
        public void ThenICanSeeThatPageWithTitleIsDisplayed(string title)
        {
            var page = ScenarioContext.Current.Get<UbsBasePage>(ContextConstants.UbsPage).GetContent<UbsBasePage>();
            StringAssert.AreEqualIgnoringCase(title, page.GetPageTitle());
        }
    }
}
