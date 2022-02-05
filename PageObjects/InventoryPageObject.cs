﻿using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabs.PageObjects
{
    internal class InventoryPageObject
    {
        public InventoryPageObject(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Id, Using = "react-burger-menu-btn")]
        public IWebElement menuButton { get; set; }

        [FindsBy(How =How.CssSelector, Using = "#item_4_img_link > img:nth-child(1)")]
        public IWebElement sauceLabsBackpack { get; set; }
    }
}
