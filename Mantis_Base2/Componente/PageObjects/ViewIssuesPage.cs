using Componente.Comum;
using Dados.DataObjects;
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

        public ViewPage SearchAndAccess(Issue issue)
        {
            txtSearch.typeText(issue.Id);
            btnApplyFilter.click();

            issueOnGrid(issue.Id).click();

            return new ViewPage();
        }
    }
}
