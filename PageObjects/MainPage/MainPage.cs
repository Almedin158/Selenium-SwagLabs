using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabs.PageObjects.MainPage
{
    internal partial class MainPage
    {
        public MainPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }
    }
}
