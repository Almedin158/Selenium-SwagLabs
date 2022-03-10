using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
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
    internal class SidebarTest<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        [SetUp]
        public void Initialize()
        {
            Selenium.Driver.Init(typeof(TWebDriver).Name);
            PageAssembly.Pages.Init();
            Selenium.Driver.GoTo(PageAssembly.Pages.Login._url);
        }
        [Test]
        public void OpenSidebar()
        {
            PageAssembly.Pages.Login.LogIn("standard_user", "secret_sauce");
            Selenium.SetMethods.ClickButton(PageAssembly.Pages.MainPage.sidebarOpenButton);
        }
        public void CloseSidebar()
        {
            PageAssembly.Pages.Login.LogIn("standard_user", "secret_sauce");
            Selenium.SetMethods.ClickButton(PageAssembly.Pages.MainPage.sidebarOpenButton);
            Selenium.SetMethods.ClickButton(PageAssembly.Pages.MainPage.sidebarCloseButton);
        }
        [TearDown]
        public void CleanUp()
        {
            Selenium.Driver.current.Quit();
        }
    }
}
