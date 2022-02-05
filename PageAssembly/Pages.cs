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
        public static LoginPageObject loginPageObject;
        [ThreadStatic]
        public static InventoryPageObject inventoryPageObject;

        public static void Init()
        {
            loginPageObject = new LoginPageObject(Selenium.Driver.current);
            inventoryPageObject = new InventoryPageObject(Selenium.Driver.current);
        }
    }
}
