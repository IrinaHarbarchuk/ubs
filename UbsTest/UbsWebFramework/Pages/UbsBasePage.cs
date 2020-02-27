using System.Linq;
using OpenQA.Selenium;

namespace UbsWebFramework.Pages
{
    public class UbsBasePage : WebController
    {
        private const string MenuTabs = "//*[@id='mainmenu']/li";
        private const string MenuItems = "//*[@id='mainmenu']/li/div/ul/li";
        private const string Title = "//*[@id='main']/header/div/div/div/div/h1";
        private const string Logo = "header__logoTitle";

        private IWebDriver _driver;

        public UbsBasePage(IWebDriver webDriver) : base(webDriver)
        {
            _driver = webDriver;
        }

        public void SelectMenuItemFromTab(string menuTab, string menuItem)
        {
            var tab = GetMenuTab(menuTab);
            tab.Click();
            _driver.WaitElementToHaveAttribute(tab, "aria-expanded", "true");
            _driver.GetElementsByXpath(MenuItems).FirstOrDefault(it => it.Text.Equals(menuItem))?.Click();
            WaitForLogoToBeDisplayed();
        }

        public void OpenPage(string page)
        {
            _driver.Navigate().GoToUrl(page);
            AcceptCookies();
            WaitForLogoToBeDisplayed();           
        }

        private IWebElement GetMenuTab(string menuTab)
        {
            return _driver.GetElementsByXpath(MenuTabs).FirstOrDefault(it => it.Text.Equals(menuTab));
        }

        private IWebElement GetLogo()
        {
            return _driver.GetElementByClass(Logo);
        }

        public string GetPageTitle()
        {
            var element = _driver.FindElement(By.XPath(Title));
            return element.Text;
        }

        public void AcceptCookies()
        {
            if(_driver.Manage().Cookies.AllCookies.FirstOrDefault(it=>it.Name.Equals("ubs_cookie_settings_1.2"))==null)
            {
                _driver.Manage().Cookies.AddCookie(new Cookie("ubs_cookie_settings_1.2", "0-1-2-3"));
                _driver.Navigate().Refresh();
            }    
        }

        public void WaitForLogoToBeDisplayed()
        {
            _driver.WaitForElementToBeDislpayed(GetLogo());
        }
    }
}
