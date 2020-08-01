using Componente.Comum;
using Dados.DataObjects;
using OpenQA.Selenium;
using Relatorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Componente.PageObjects
{
    public class ReportPage : CommonPage
    {
        internal static string Url { get { return "bug_report_page.php"; } }

        internal IWebElement dropChooseCategory => Utils.findElement(By.Name("category_id"));
        internal IWebElement txtSummary => Utils.findElement(By.Name("summary"));
        internal IWebElement txtDescription => Utils.findElement(By.Name("description"));
        internal IWebElement radioPrivate => Utils.findElement(By.XPath("//label[contains(text(),' private')]"));
        internal IWebElement btnSubmitReport => Utils.findElement(By.CssSelector("form[name='report_bug_form'] [type=submit]"));


        public ReportPage(Login login)
        {
            try
            {
                dropChooseCategory.moveToElement();
                Relatorio.AddLog(Status.Info, $"Página {Url} acessada");
            }
            catch (NoSuchElementException e)
            {
                if (SeleniumWebDriver.URLAtual.Contains(Url))
                {
                    if (SeleniumWebDriver.URLAtual.Contains(SelectProjectPage.Url))
                    {
                        SelectProjectPage select = new SelectProjectPage();
                        select.SelecionarProjetoId(login);
                    }
                    else
                        throw new Exception($"Sistema abriu uma página inesperada: '{SeleniumWebDriver.URLAtual}'");
                }
                else
                    throw e;
            }
        }

        public ViewIssuesPage CadastrarIssue(Issue issue)
        {
            dropChooseCategory.dropDownSelectByText(issue.Category);
            txtSummary.typeText(issue.Summary);
            txtDescription.typeText(issue.Description);
            
            if(issue.ViewStatus.ToLower() == "private")
                radioPrivate.click();

            btnSubmitReport.Click();

            var view = new ViewIssuesPage();

            issue.Id = btnRecentlyVisitedFirst.Text;

            Relatorio.AddLog(Status.Pass, $"Issue cadastrada, gerada com id '{issue.Id}'");

            return view;
        }
    }
}
