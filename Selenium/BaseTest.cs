using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabs.Selenium
{
    internal class BaseTest<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        [SetUp]
        public void Initialize()
        {
            Selenium.Driver.Init(typeof(TWebDriver).Name);
            PageAssembly.Pages.Init();
            Selenium.Driver.GoTo(PageAssembly.Pages.Login._url);
        }
        [TearDown]
        public void CleanUp()
        {
            Selenium.Driver.current.Quit();
        }
    }
}
