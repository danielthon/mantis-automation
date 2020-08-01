using Componente.Comum;
using OpenQA.Selenium;
using System;

namespace Componente.PageObjects
{
    public class MyViewPage
    {
        internal static string Url { get { return "my_view_page.php"; } }


        internal IWebElement spanLogin => Utils.FindElement(By.CssSelector("td[class=login-info-left]>span:first-child"));

        internal IWebElement btnMyView=> Utils.FindElement(By.CssSelector("td[class=menu]>a:nth-child(3)"));
        internal IWebElement btnViewIssues => Utils.FindElement(By.CssSelector("td[class=menu]>a:nth-child(3)"));
        internal IWebElement btnReportIssue => Utils.FindElement(By.CssSelector("td[class=menu]>a:nth-child(3)"));
        internal IWebElement btnLogout => Utils.FindElement(By.CssSelector("td[class=menu]>a:last-child"));


        public MyViewPage()
        {
            try
            {
                spanLogin.MoveToElement();
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
