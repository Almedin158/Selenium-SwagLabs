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
    internal static class Driver
    {
        [ThreadStatic]
        public static IWebDriver driver;

        public static void Init(string _webDriverName)
        {
            if (_webDriverName == "ChromeDriver")
            {
                driver = new ChromeDriver();
            }
            else if(_webDriverName == "FirefoxDriver")
            {
                driver = new FirefoxDriver();
            }
            driver.Manage().Window.Maximize();
        }

        public static IWebDriver current => driver ?? throw new NullReferenceException("Driver is null.");

        public static void GoTo(string _url)
        {
            if (!_url.StartsWith("http"))
            {
                _url = $"http://{_url}";
            }
            current.Navigate().GoToUrl(_url);
        }
    }
}
