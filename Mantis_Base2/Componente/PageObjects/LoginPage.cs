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


        internal IWebElement txtUsername => Utils.FindElement(By.Name("username"));
        internal IWebElement txtPassword => Utils.FindElement(By.Name("password"));
        internal IWebElement btnLogin => Utils.FindElement(By.CssSelector("[type=submit]"));


        public MyViewPage FazerLogin()
        {
            txtUsername.TypeText("daniel.pinheiro");
            txtPassword.TypeText("solideogloria");
            btnLogin.Click();

            return new MyViewPage();
        }
    }
}
