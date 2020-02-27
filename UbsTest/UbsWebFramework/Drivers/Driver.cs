using OpenQA.Selenium;

namespace UbsWebFramework.Drivers
{
    internal abstract class Driver
    {
        internal abstract IWebDriver CreateDriver();
    }
}
