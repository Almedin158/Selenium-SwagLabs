using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabs.TestCases
{
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    [Parallelizable(ParallelScope.All)]
    internal class LogInTestFirefox<TWebDriver> where TWebDriver:IWebDriver,new()
    {
        [SetUp]
        public void Initialize()
        {
            Selenium.Driver.Init(typeof(TWebDriver).Name);
            PageAssembly.Pages.Init();
            Selenium.Driver.GoTo("www.saucedemo.com");
        }
        [Test]
        public void StandardUserLogIn()
        {
            PageObjects.LoginPageObject loginPage = new PageObjects.LoginPageObject(Selenium.Driver.current);
            PageObjects.InventoryPageObject inventoryPage =  loginPage.LogIn("standard_user", "secret_sauce");
            Assert.IsTrue(inventoryPage.menuButton.Displayed && inventoryPage.menuButton.Enabled);
            //Console.WriteLine(inventoryPage.sauceLabsBackpack.GetAttribute("src"));
            Assert.IsTrue(inventoryPage.sauceLabsBackpack.GetAttribute("src").EndsWith("/static/media/sauce-backpack-1200x1500.34e7aa42.jpg"));
        }
        [Test]
        public void LockedOutUserLogIn()
        {
            PageObjects.LoginPageObject loginPage = new PageObjects.LoginPageObject(Selenium.Driver.current);
            PageObjects.InventoryPageObject inventoryPage = loginPage.LogIn("locked_out_user", "secret_sauce");
            Assert.IsTrue(loginPage.errorButton.Text.Contains("Epic sadface: Sorry, this user has been locked out."));
        }
        [Test]
        public void ProblemUserLogIn()
        {
            PageObjects.LoginPageObject loginPage = new PageObjects.LoginPageObject(Selenium.Driver.current);
            PageObjects.InventoryPageObject inventoryPage = loginPage.LogIn("problem_user", "secret_sauce");
            //Assert.IsTrue(inventoryPage.menuButton.Displayed && inventoryPage.menuButton.Enabled);
            Console.WriteLine(inventoryPage.sauceLabsBackpack.GetAttribute("src"));
            Assert.IsTrue(inventoryPage.sauceLabsBackpack.GetAttribute("src").EndsWith("/static/media/sauce-backpack-1200x1500.34e7aa42.jpg"));

        }
        [Test]
        public void PerformanceGlitchUserLogIn()
        {
            PageObjects.LoginPageObject loginPage = new PageObjects.LoginPageObject(Selenium.Driver.current);
            Selenium.Driver.current.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(3);//Site must load within 3 seconds, else the test fails.
            PageObjects.InventoryPageObject inventoryPage = loginPage.LogIn("performance_glitch_user", "secret_sauce");
            Assert.IsTrue(inventoryPage.menuButton.Displayed && inventoryPage.menuButton.Enabled);
        }
        //Login test without username
        [Test]
        public void MissingUsernameUserLogIn()
        {
            PageObjects.LoginPageObject loginPage = new PageObjects.LoginPageObject(Selenium.Driver.current);
            loginPage.LogIn("", "secret_sauce");
            Assert.IsTrue(loginPage.errorButton.Text.Contains("Epic sadface: Username is required"));
        }
        //Login test without password
        [Test]
        public void MissingPasswordUserLogIn()
        {
            PageObjects.LoginPageObject loginPage = new PageObjects.LoginPageObject(Selenium.Driver.current);
            loginPage.LogIn("Almedin", "");
            Assert.IsTrue(loginPage.errorButton.Text.Contains("Epic sadface: Password is required"));
        }
        //Login test with incorrect password and/or username
        [Test]
        public void IncorrectUsernameOrPasswordUserLogIn()
        {
            PageObjects.LoginPageObject loginPage = new PageObjects.LoginPageObject(Selenium.Driver.current);
            loginPage.LogIn("Almedin", "Password");
            Assert.IsTrue(loginPage.errorButton.Text.Contains("Epic sadface: Username and password do not match any user in this service"));
        }
        [TearDown]
        public void CleanUp()
        {
            Selenium.Driver.current.Quit();
        }
    }
}
