using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SwagLabs.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabs.TestCases
{
    [Parallelizable(ParallelScope.All)]
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    internal class SidebarTest<TWebDriver> : Selenium.BaseTest<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        public string loginUrl = "https://www.saucedemo.com/";
        public string aboutUrl = "https://saucelabs.com/";

        [Test]
        public void OpenSidebar()
        {
            PageAssembly.Pages.Login.LogIn("standard_user", "secret_sauce");
            PageAssembly.Pages.MainPage.sidebarOpenButton.ClickButton();
        }
        [Test]
        public void CloseSidebar()
        {
            PageAssembly.Pages.Login.LogIn("standard_user", "secret_sauce");
            PageAssembly.Pages.MainPage.sidebarOpenButton.ClickButton();
            PageAssembly.Pages.MainPage.sidebarCloseButton.ClickButton();
        }
        [Test]
        public void LogOutTest()
        {
            PageAssembly.Pages.Login.LogIn("standard_user", "secret_sauce");
            PageAssembly.Pages.MainPage.sidebarOpenButton.ClickButton();
            PageAssembly.Pages.MainPage.logoutButton.ClickButton();
            Selenium.Driver.ExplicitWaitUrlMatch(3, loginUrl);
            PageAssembly.Pages.MainPage.AssertLogout();
        }
        [Test]
        public void AboutPageTest()
        {
            PageAssembly.Pages.Login.LogIn("standard_user", "secret_sauce");
            PageAssembly.Pages.MainPage.sidebarOpenButton.ClickButton();
            PageAssembly.Pages.MainPage.aboutButton.ClickButton();
            Selenium.Driver.ExplicitWaitUrlMatch(3, aboutUrl);
            PageAssembly.Pages.MainPage.AssertAboutPageRedirection();
        }
    }
}
