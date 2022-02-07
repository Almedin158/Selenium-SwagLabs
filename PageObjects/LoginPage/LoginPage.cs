using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SwagLabs.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabs.PageObjects.LoginPage
{
    internal partial class LoginPage
    {
        public LoginPage(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        public string _url = "www.saucedemo.com";

        public void LogIn(string _username, string _password)
        {
            username.EnterText(_username);
            password.EnterText(_password);
            login.ClickButton();
            //return new InventoryPageObject(Selenium.Driver.current);
        }
    }
}
