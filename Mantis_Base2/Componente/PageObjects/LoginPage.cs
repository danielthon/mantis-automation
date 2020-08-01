using Componente.Comum;
using Dados.DataObjects;
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


        public MyViewPage FazerLogin(Login login)
        {
            txtUsername.typeText(login.Username);
            txtPassword.typeText(login.Password);
            btnLogin.Click();

            return new MyViewPage(login);
        }
    }
}
