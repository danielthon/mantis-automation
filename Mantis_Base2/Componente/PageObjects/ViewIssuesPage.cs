using Componente.Comum;
using OpenQA.Selenium;
using System;

namespace Componente.PageObjects
{
    public class ViewIssuesPage : CommonPage
    {
        internal static string Url { get { return "view_all_bug_page.php"; } }

        internal static IWebElement txtSearch => Utils.findElement(By.CssSelector("[id='filter_open'] input[name='search']"));
        internal static IWebElement btnApplyFilter => Utils.findElement(By.CssSelector("[id='filter_open'] input[type='submit']"));

        internal static IWebElement issueOnGrid(string codigo) => Utils.findElement(By.XPath($"//*[@id='buglist']//a[contains(text(),'{codigo}')]"));

        public ViewIssuesPage()
        {
            txtSearch.moveToElement();
        }

        public ViewIssuesPage SearchAndVerify(string codigo)
        {
            //0003748
            //[All Projects] 7EI2PODHPN
            //Teste 003
            //Teste com caractere é$p&ç;ãl
            //private

            txtSearch.typeText(codigo);
            btnApplyFilter.click();

            issueOnGrid("0003748").click();

            ViewPage view = new ViewPage();
            view.VerificarIssue();

            SeleniumWebDriver.GoBack();

            return new ViewIssuesPage();
        }
    }
}
