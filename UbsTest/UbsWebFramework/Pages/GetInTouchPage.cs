using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace UbsWebFramework.Pages
{
    public class GetInTouchPage : UbsBasePage
    {
        private const string Submit = "actionbutton__button";
        private const string ErrorMessages = "form__error";
        private const string Labels = "grid-form__labelCol";

        private IWebDriver _driver;

        public GetInTouchPage(IWebDriver webDriver) : base(webDriver)
        {
            _driver = webDriver;
        }

        public void ClickSubmitBtn()
        {
            _driver.GetElementByClass(Submit).Click();
        }

        public ReadOnlyCollection<IWebElement> GetErrorMessages()
        {
            return _driver.GetElementsByClass(ErrorMessages);
        }

        public ReadOnlyCollection<IWebElement> GetLabels()
        {
            return _driver.GetElementsByClass(Labels);
        }
    }
}
