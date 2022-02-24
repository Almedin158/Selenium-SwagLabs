using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
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
        public static WebDriverWait webDriverWait;

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

        public static void SwitchWindowHandles(int _tabPosition)
        {
            driver.SwitchTo().Window(driver.WindowHandles[_tabPosition]);
        }
        public static void ExplicitWaitUrlMatch(int _timeSpan, string _url)
        {
            webDriverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(_timeSpan));
            webDriverWait.Until(ExpectedConditions.UrlMatches(_url));
        }
    }
}
