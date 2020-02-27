using System;
using OpenQA.Selenium;
using UbsWebFramework.Drivers;

namespace UbsWebFramework
{
    public static class WebDriverService
    {
        private static IWebDriver _webDriver = null;

        public static IWebDriver CreateWebDriver(string browserType)
        {
            Driver driver;
            if (string.IsNullOrEmpty(browserType)) throw new NullReferenceException("Browser Type must be set with valid not null value.");
            switch (browserType.ToLowerInvariant())
            {
                case "ie":
                case "internetexplorer":
                    throw new NotImplementedException("Driver for Internet explorer was not added to project right now.");
                case "firefox":
                case "mozilla":
                   driver = new FirefoxDriver(); 
                    break;
                case "chrome":
                    driver = new ChromeDriver();
                    break;
                default:
                    throw new ApplicationException($"{browserType} is not supported.");
            }
            return driver.CreateDriver();
        }
    }
}
