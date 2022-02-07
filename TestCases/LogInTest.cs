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
    internal class LogInTest<TWebDriver> where TWebDriver:IWebDriver,new()
    {
        [SetUp]
        public void Initialize()
        {
            Selenium.Driver.Init(typeof(TWebDriver).Name);
            PageAssembly.Pages.Init();
            Selenium.Driver.GoTo(PageAssembly.Pages.Login._url);
        }
        [Test]
        public void StandardUserLogIn()
        {
            PageAssembly.Pages.Login.LogIn("standard_user", "secret_sauce");
            PageAssembly.Pages.MainPage.AssertLoggedInSuccesfully();
        }
        [Test]
        public void LockedOutUserLogIn()
        {
            PageAssembly.Pages.Login.LogIn("locked_out_user", "secret_sauce");
            PageAssembly.Pages.Login.AssertLockedUserLogin();
        }
        [Test]
        public void ProblemUserLogIn()
        {
            PageAssembly.Pages.Login.LogIn("problem_user", "secret_sauce");
            PageAssembly.Pages.MainPage.AssertMainPageConsistency();

        }
        [Test]
        public void PerformanceGlitchUserLogIn()
        {
            Selenium.Driver.current.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(3);//Site must load within 3 seconds, else the test fails.
            PageAssembly.Pages.Login.LogIn("performance_glitch_user", "secret_sauce");
            PageAssembly.Pages.MainPage.AssertLoggedInSuccesfully();
        }
        //Login test without username
        [Test]
        public void MissingUsernameUserLogIn()
        {
            PageAssembly.Pages.Login.LogIn("", "secret_sauce");
            PageAssembly.Pages.Login.AssertBlankUserNameLogin();
        }
        //Login test without password
        [Test]
        public void MissingPasswordUserLogIn()
        {
            PageAssembly.Pages.Login.LogIn("Almedin", "");
            PageAssembly.Pages.Login.AssertBlankPasswordLogin();
        }
        //Login test with incorrect password and/or username
        [Test]
        public void IncorrectUsernameOrPasswordUserLogIn()
        {
            PageAssembly.Pages.Login.LogIn("Almedin", "Password");
            PageAssembly.Pages.Login.AssertIncorrectUserNameOrPasswordLogin();
        }
        [TearDown]
        public void CleanUp()
        {
            Selenium.Driver.current.Quit();
        }
    }
}
