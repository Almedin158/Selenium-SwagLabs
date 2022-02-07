using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabs.PageObjects.LoginPage
{
    internal partial class LoginPage
    {
        public void AssertLockedUserLogin()
        {
            Assert.IsTrue(errorButton.Text.Contains("Epic sadface: Sorry, this user has been locked out."));
        }
        public void AssertBlankUserNameLogin()
        {
            Assert.IsTrue(errorButton.Text.Contains("Epic sadface: Username is required"));
        }
        public void AssertBlankPasswordLogin()
        {
            Assert.IsTrue(errorButton.Text.Contains("Epic sadface: Password is required"));
        }
        public void AssertIncorrectUserNameOrPasswordLogin()
        {
            Assert.IsTrue(errorButton.Text.Contains("Epic sadface: Username and password do not match any user in this service"));
        }
    }
}
