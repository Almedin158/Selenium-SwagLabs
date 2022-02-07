using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabs.PageObjects.LoginPage
{
    internal partial class LoginPage
    {
        [FindsBy(How = How.Id, Using = "user-name")]
        public IWebElement username { get; set; }

        [FindsBy(How = How.Id, Using = "password")]
        public IWebElement password { get; set; }

        [FindsBy(How = How.Id, Using = "login-button")]
        public IWebElement login { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".error-message-container")]
        public IWebElement errorButton { get; set; }

        [FindsBy(How = How.Id, Using = "react-burger-menu-btn")]
        public IWebElement menuButton { get; set; }
    }
}
