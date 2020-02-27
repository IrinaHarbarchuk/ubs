using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace UbsWebFramework
{
    public static class DriverHelper
    {
        public static IWebElement GetElementByClass(this IWebDriver driver, string className)
        {
            return driver.FindElement(By.ClassName(className));
        }

        public static ReadOnlyCollection<IWebElement> GetElementsByClass(this IWebDriver driver, string className)
        {
            return driver.FindElements(By.ClassName(className));
        }

        public static ReadOnlyCollection<IWebElement> GetElementsByXpath(this IWebDriver driver, string xpath)
        {
            return driver.FindElements(By.XPath(xpath));
        }

        public static bool WaitElementToHaveAttribute(this IWebDriver driver, IWebElement element, string attribute, string expectedAttr)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(attr=>element.GetAttribute(attribute).Equals(expectedAttr));
        }

        public static bool WaitForElementToBeDislpayed(this IWebDriver driver, IWebElement element)
        {
            return new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(res => element.Displayed);
        }
    } 
}