using System;
using OpenQA.Selenium;

namespace UbsWebFramework.Drivers
{
    internal class FirefoxDriver: Driver
    {
        internal override IWebDriver CreateDriver()
        {
            throw new NotImplementedException("There's no implementation for FirefoxDriver.");
        }
    }
}
