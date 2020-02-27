using NUnit.Framework;
using OpenQA.Selenium;
using System.Linq;
using TechTalk.SpecFlow;
using UbsWebFramework.Pages;

namespace UbsTest.StepDefinitions
{
    [Binding]
    public class GetInTouchPageUISteps
    {
        public IWebDriver Driver;

        public GetInTouchPageUISteps(IWebDriver driver)
        {
            Driver = driver;
        }

        [Given(@"I go to '(.*)' url on UBS website")]
        public void GivenIGoToUrlOnUBSWebsite(string url)
        {
            var gitPage = new GetInTouchPage(Driver);
            gitPage.OpenPage(UbsUrlHelper.GetInTouchUrl);
            ScenarioContext.Current.Set(gitPage, ContextConstants.GetInTouchPage);
        }
        
        [When(@"I click on 'Submit' button on UBS website")]
        public void WhenIClickOnButtonOnUBSWebsite()
        {
            var page = ScenarioContext.Current.Get<GetInTouchPage>(ContextConstants.GetInTouchPage).GetContent<GetInTouchPage>();
            page.ClickSubmitBtn();
        }
        
        [Then(@"I can see that validation messages are displayed on UBS website near all obligatory fields")]
        public void ThenICanSeeThatValidationMessagesAreDisplayedOnUBSWebsiteNearAllObligatoryFields()
        {
            var page = ScenarioContext.Current.Get<GetInTouchPage>(ContextConstants.GetInTouchPage).GetContent<GetInTouchPage>();
            Assert.AreEqual(page.GetLabels().ToList().FindAll(it=>it.Text.Contains("*")).Count, page.GetErrorMessages().Count, "It seems that there're no error messages near some obligatory fields!");
        }
    }
}
