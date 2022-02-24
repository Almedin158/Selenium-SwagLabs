using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabs.PageObjects.MainPage
{
    internal partial class MainPage
    {
        public void AssertLoggedInSuccesfully()
        {
            Assert.True(menuButton.Displayed && menuButton.Enabled);
        }
        public void AssertMainPageConsistency()
        {
            Assert.IsTrue(sauceLabsBackpack.GetAttribute("src").EndsWith("/static/media/sauce-backpack-1200x1500.34e7aa42.jpg"));
        }
        public void AssertTwitterRedirectionButton()
        {
            Assert.AreEqual("https://twitter.com/saucelabs", Selenium.Driver.driver.Url);
        }
        public void AssertFacebookRedirectionButton()
        {
            Assert.AreEqual("https://www.facebook.com/saucelabs", Selenium.Driver.driver.Url);
        }
        public void AssertLinkedInRedirectionButton()
        {
            Assert.IsTrue("https://www.linkedin.com/company/sauce-labs/"== Selenium.Driver.driver.Url);
        }
    }
}
