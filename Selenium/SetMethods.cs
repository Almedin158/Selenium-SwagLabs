using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabs.Selenium
{
    internal static class SetMethods
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void EnterText(this IWebElement element, string value)
        {
            element.SendKeys(value);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public static void ClickButton(this IWebElement element)
        {
            element.Click();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public static void SubmitForm(this IWebElement element)
        {
            element.Submit();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="value"></param>
        public static void SelectDrowDown(this IWebElement element, string value)
        {
            new SelectElement(element).SelectByText(value);
        }
    }
}
