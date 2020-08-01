using Componente.Comum;
using OpenQA.Selenium;
using System;

namespace Componente.PageObjects
{
    public class MyViewPage : CommonPage
    {
        internal static string Url { get { return "my_view_page.php"; } }


        public MyViewPage()
        {
            try
            {
                spanLogin.moveToElement();
            }
            catch (NoSuchElementException e)
            {
                if (SeleniumWebDriver.URLAtual != Url)
                {
                    if (SeleniumWebDriver.URLAtual == SeleniumWebDriver.URLRaiz + LoginPage.Url)
                    {
                        LoginPage login = new LoginPage();
                        login.FazerLogin();
                    }
                    else
                        throw new Exception($"Sistema abriu uma página inesperada: '{SeleniumWebDriver.URLAtual}'");
                }
                else
                    throw e;
            }
        }
    }
}
