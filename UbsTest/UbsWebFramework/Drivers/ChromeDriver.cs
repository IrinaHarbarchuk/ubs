using OpenQA.Selenium;

namespace UbsWebFramework.Drivers
{
    internal class ChromeDriver: Driver
    {
        internal override IWebDriver CreateDriver()
        {
            return new OpenQA.Selenium.Chrome.ChromeDriver();
        }
    }
}
