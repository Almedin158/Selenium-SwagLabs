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
        public void ClickTwitterButton()
        {
            Selenium.SetMethods.ClickButton(twitterButton);
            //return new InventoryPageObject(Selenium.Driver.current);
        }
        public void ClickFacebookButton()
        {
            Selenium.SetMethods.ClickButton(facebookButton);
            //return new InventoryPageObject(Selenium.Driver.current);
        }
        public void ClickLinkedInButton()
        {
            Selenium.SetMethods.ClickButton(linkedInButton);
            //return new InventoryPageObject(Selenium.Driver.current);
        }
    }
}
