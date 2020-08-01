using Componente.Comum;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Componente.PageObjects
{
    public class LoginPage
    {
        internal static string Url { get { return "login_page.php"; } }


        internal IWebElement txtUsername => Utils.findElement(By.Name("username"));
        internal IWebElement txtPassword => Utils.findElement(By.Name("password"));
        internal IWebElement btnLogin => Utils.findElement(By.CssSelector("[type=submit]"));


        public MyViewPage FazerLogin()
        {
            txtUsername.typeText("daniel.pinheiro");
            txtPassword.typeText("solideogloria");
            btnLogin.Click();

            return new MyViewPage();
        }
    }
}
