using SwagLabs.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabs.PageAssembly
{
    internal class Pages
    {
        [ThreadStatic]
        public static PageObjects.LoginPage.LoginPage Login;
        [ThreadStatic]
        public static PageObjects.MainPage.MainPage MainPage;
        public static void Init()
        {
            Login = new PageObjects.LoginPage.LoginPage(Selenium.Driver.current);
            MainPage = new PageObjects.MainPage.MainPage(Selenium.Driver.current);
        }
    }
}
