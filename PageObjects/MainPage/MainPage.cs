using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using SwagLabs.Selenium;
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
            PageAssembly.Pages.MainPage.twitterButton.ClickButton();
            //return new InventoryPageObject(Selenium.Driver.current);
        }
        public void ClickFacebookButton()
        {
            PageAssembly.Pages.MainPage.facebookButton.ClickButton();
            //return new InventoryPageObject(Selenium.Driver.current);
        }
        public void ClickLinkedInButton()
        {
            //Selenium.SetMethods.ClickButton(linkedInButton);
            PageAssembly.Pages.MainPage.linkedInButton.ClickButton();
            //return new InventoryPageObject(Selenium.Driver.current);
        }
    }
}
