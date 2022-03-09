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
    [Parallelizable(ParallelScope.All)]
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(FirefoxDriver))]
    internal class SortProductsTest<TWebDriver> where TWebDriver : IWebDriver, new()
    {
        [SetUp]
        public void Initialize()
        {
            Selenium.Driver.Init(typeof(TWebDriver).Name);
            PageAssembly.Pages.Init();
            Selenium.Driver.GoTo(PageAssembly.Pages.Login._url);
        }
        [Test]
        public void SortNameAscending()
        {
            PageAssembly.Pages.Login.LogIn("standard_user", "secret_sauce");
            IReadOnlyCollection<IWebElement> products = Selenium.Driver.driver.FindElements(By.ClassName("inventory_item_name"));
            List<string> productPrices = new List<string>();
            List<string> productPricesSorted = new List<string>();
            foreach (var product in products)
            {
                productPrices.Add(product.Text);
            }
            productPrices.Sort();
            Selenium.SetMethods.SelectDrowDownByValue(PageAssembly.Pages.MainPage.sortDropDownButton, "az");
            products = Selenium.Driver.driver.FindElements(By.ClassName("inventory_item_name"));
            foreach (var product in products)
            {
                productPricesSorted.Add(product.Text);
            }
            Assert.IsTrue(productPrices.SequenceEqual(productPricesSorted));
        }
        [Test]
        public void SortNameDescending()
        {
            PageAssembly.Pages.Login.LogIn("standard_user", "secret_sauce");
            IReadOnlyCollection<IWebElement> products = Selenium.Driver.driver.FindElements(By.ClassName("inventory_item_name"));
            List<string> productPrices = new List<string>();
            List<string> productPricesSorted = new List<string>();
            foreach (var product in products)
            {
                productPrices.Add(product.Text);
            }
            productPrices.Sort();
            productPrices.Reverse();
            Selenium.SetMethods.SelectDrowDownByValue(PageAssembly.Pages.MainPage.sortDropDownButton, "az");
            products = Selenium.Driver.driver.FindElements(By.ClassName("inventory_item_name"));
            foreach (var product in products)
            {
                productPricesSorted.Add(product.Text);
            }
            Assert.IsTrue(productPrices.SequenceEqual(productPricesSorted));
        }
        [Test]
        public void SortPriceAscending()
        {
            PageAssembly.Pages.Login.LogIn("standard_user", "secret_sauce");
            IReadOnlyCollection<IWebElement> products = Selenium.Driver.driver.FindElements(By.ClassName("inventory_item_price"));
            List<double> productPrices = new List<double>();
            List<double> productPricesSorted = new List<double>();
            foreach (var product in products)
            {
                productPrices.Add(Convert.ToDouble(product.Text.Trim('$')));
            }
            productPrices.Sort();
            Selenium.SetMethods.SelectDrowDownByValue(PageAssembly.Pages.MainPage.sortDropDownButton, "lohi");
            products = Selenium.Driver.driver.FindElements(By.ClassName("inventory_item_price"));
            foreach (var product in products)
            {
                productPricesSorted.Add(Convert.ToDouble(product.Text.Trim('$')));
            }
            Assert.IsTrue(productPrices.SequenceEqual(productPricesSorted));
        }
        [Test]
        public void SortPriceDescending()
        {
            PageAssembly.Pages.Login.LogIn("standard_user", "secret_sauce");
            IReadOnlyCollection<IWebElement> products = Selenium.Driver.driver.FindElements(By.ClassName("inventory_item_price"));
            List<double> productPrices = new List<double>();
            List<double> productPricesSorted = new List<double>();
            foreach (var product in products)
            {
                productPrices.Add(Convert.ToDouble(product.Text.Trim('$')));
            }
            productPrices.Sort();
            productPrices.Reverse();
            Selenium.SetMethods.SelectDrowDownByValue(PageAssembly.Pages.MainPage.sortDropDownButton, "hilo");
            products = Selenium.Driver.driver.FindElements(By.ClassName("inventory_item_price"));
            foreach (var product in products)
            {
                productPricesSorted.Add(Convert.ToDouble(product.Text.Trim('$')));
            }
            Assert.IsTrue(productPrices.SequenceEqual(productPricesSorted));
        }
        [TearDown]
        public void CleanUp()
        {
            Selenium.Driver.current.Quit();
        }
    }
}
