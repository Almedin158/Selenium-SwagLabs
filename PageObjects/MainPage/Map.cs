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
        [FindsBy(How = How.Id, Using = "react-burger-menu-btn")]
        public IWebElement menuButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = "#item_4_img_link > img:nth-child(1)")]
        public IWebElement sauceLabsBackpack { get; set; }

        [FindsBy(How=How.CssSelector, Using = ".social_twitter > a:nth-child(1)")]
        public IWebElement twitterButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".social_facebook > a:nth-child(1)")]
        public IWebElement facebookButton { get; set; }

        [FindsBy(How = How.CssSelector, Using = ".social_linkedin > a:nth-child(1)")]
        public IWebElement linkedInButton { get; set; }

        [FindsBy(How =How.CssSelector, Using= ".product_sort_container")]
        public IWebElement sortDropDownButton { get; set; }

        [FindsBy(How =How.Id , Using = "react-burger-menu-btn")]
        public IWebElement sidebarOpenButton { get; set; }

        [FindsBy(How =How.Id, Using = "react-burger-cross-btn")]
        public IWebElement sidebarCloseButton { get; set; }

        [FindsBy(How =How.Id,Using = "logout_sidebar_link")]
        public IWebElement logoutButton { get; set; }

        [FindsBy(How=How.Id,Using = "about_sidebar_link")]
        public IWebElement aboutButton { get; set; }
    }
}
