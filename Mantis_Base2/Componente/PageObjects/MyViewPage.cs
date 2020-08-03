using Componente.Comum;
using Dados.DataObjects;
using OpenQA.Selenium;
using Relatorios;
using System;

namespace Componente.PageObjects
{
    public class MyViewPage : CommonPage
    {
        internal static string Url { get { return "my_view_page.php"; } }


        public MyViewPage(Login login)
        {
            try
            {
                spanLogin.moveToElement();
                Relatorio.addLog(Status.Info, $"Página {Url} acessada");
            }
            catch (NoSuchElementException e)
            {
                if (SeleniumWebDriver.URLAtual != Url)
                {
                    if (SeleniumWebDriver.URLAtual == SeleniumWebDriver.URLRaiz + LoginPage.Url)
                    {
                        LoginPage loginPage = new LoginPage();
                        loginPage.FazerLogin(login);
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
