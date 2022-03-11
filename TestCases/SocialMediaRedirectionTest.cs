using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SwagLabs.TestCases
{
    [Parallelizable(ParallelScope.All)]
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    internal class SocialMediaRedirectionTest<TWebDriver> : Selenium.BaseTest<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        string twitterUrl = "https://twitter.com/saucelabs";
        string facebookUrl = "https://www.facebook.com/saucelabs";
        string linkedInUrl = "https://www.linkedin.com/company/sauce-labs/";

        [Test]
        public void TwitterRedirection()
        {
            //Write the assert method/s, also clean up the code. YOU WILL GET YOUR MONEY WHEN YOU FIX THIS DAMN CODE.
            PageAssembly.Pages.Login.LogIn("standard_user", "secret_sauce");
            PageAssembly.Pages.MainPage.ClickTwitterButton();
            Selenium.Driver.SwitchWindowHandles(1);
            Selenium.Driver.ExplicitWaitUrlMatch(3, twitterUrl);
            PageAssembly.Pages.MainPage.AssertTwitterRedirectionButton();
        }
        [Test]
        public void FacebookRedirection()
        {
            //Write the assert method/s, also clean up the code. YOU WILL GET YOUR MONEY WHEN YOU FIX THIS DAMN CODE.
            PageAssembly.Pages.Login.LogIn("standard_user", "secret_sauce");
            PageAssembly.Pages.MainPage.ClickFacebookButton();
            Selenium.Driver.SwitchWindowHandles(1);
            Selenium.Driver.ExplicitWaitUrlMatch(3, facebookUrl);
            PageAssembly.Pages.MainPage.AssertFacebookRedirectionButton();
        }
        [Test]
        public void LinkedInRedirection()
        {
            //Write the assert method/s, also clean up the code. YOU WILL GET YOUR MONEY WHEN YOU FIX THIS DAMN CODE.
            PageAssembly.Pages.Login.LogIn("standard_user", "secret_sauce");
            PageAssembly.Pages.MainPage.ClickLinkedInButton();
            Selenium.Driver.SwitchWindowHandles(1);
            Selenium.Driver.ExplicitWaitUrlMatch(3, linkedInUrl);
            PageAssembly.Pages.MainPage.AssertLinkedInRedirectionButton();
        }
    }
}
