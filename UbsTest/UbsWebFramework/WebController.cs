using System;
using OpenQA.Selenium;

namespace UbsWebFramework
{
    public abstract class WebController
    {
        protected IWebDriver _driver;

        protected WebController(IWebDriver webDriver)
        {
            _driver = webDriver;
        }

        public T GetContent<T>() where T : WebController
        {
            return GetContent<T>(_driver);
        }

        protected T GetContent<T>(IWebDriver webDriver) where T : WebController
        {
            var args = new object[] { webDriver };
            var content = Activator.CreateInstance(typeof(T), args) as T;
            return content;
        }
    }
}