using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SwagLabs.Selenium;
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
    internal class SortProductsTest<TWebDriver> : Selenium.BaseTest<TWebDriver> where TWebDriver : IWebDriver, new()
    {
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

            PageAssembly.Pages.MainPage.sortDropDownButton.SelectDropDownByValue("az");

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
            PageAssembly.Pages.MainPage.sortDropDownButton.SelectDropDownByValue("za");
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
            PageAssembly.Pages.MainPage.sortDropDownButton.SelectDropDownByValue("lohi");
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
            PageAssembly.Pages.MainPage.sortDropDownButton.SelectDropDownByValue("hilo");



            products = Selenium.Driver.driver.FindElements(By.ClassName("inventory_item_price"));
            foreach (var product in products)
            {
                productPricesSorted.Add(Convert.ToDouble(product.Text.Trim('$')));
            }
            Assert.IsTrue(productPrices.SequenceEqual(productPricesSorted));
        }
    }
}
