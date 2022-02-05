using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SwagLabs.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabs.PageObjects
{
    internal class LoginPageObject
    {
        public LoginPageObject(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How =How.Id,Using = "user-name")]
        public IWebElement username { get; set; }

        [FindsBy(How =How.Id,Using = "password")]
        public IWebElement password { get; set; }

        [FindsBy(How =How.Id,Using = "login-button")]
        public IWebElement login { get; set; }

        [FindsBy(How =How.CssSelector,Using = ".error-message-container")]
        public IWebElement errorButton { get; set; }

        public InventoryPageObject LogIn(string _username, string _password)
        {
            username.EnterText(_username);
            Console.WriteLine(username.GetText());//Displays the typed in username in the console
            password.EnterText(_password);
            login.ClickButton();
            return new InventoryPageObject(Selenium.Driver.current);
        }
    }
}
