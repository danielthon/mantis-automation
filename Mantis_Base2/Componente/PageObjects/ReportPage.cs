using Componente.Comum;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Componente.PageObjects
{
    public class ReportPage
    {
        internal static string Url { get { return "bug_report_page.php"; } }

        internal IWebElement dropChooseCategory => Utils.findElement(By.Name("category_id"));
        internal IWebElement txtSummary => Utils.findElement(By.Name("summary"));
        internal IWebElement txtDescription => Utils.findElement(By.Name("description"));
        internal IWebElement radioPrivate => Utils.findElement(By.XPath("//label[contains(text(),' private')]"));
        internal IWebElement btnSubmitReport => Utils.findElement(By.CssSelector("form[name='report_bug_form'] [type=submit]"));


        public ReportPage()
        {
            try
            {
                dropChooseCategory.moveToElement();
            }
            catch (NoSuchElementException e)
            {
                if (SeleniumWebDriver.URLAtual.Contains(Url))
                {
                    if (SeleniumWebDriver.URLAtual.Contains(SelectProjectPage.Url))
                    {
                        SelectProjectPage select = new SelectProjectPage();
                        select.SelecionarProjetoId("145");
                    }
                    else
                        throw new Exception($"Sistema abriu uma página inesperada: '{SeleniumWebDriver.URLAtual}'");
                }
                else
                    throw e;
            }
        }

        public MyViewPage CadastrarIssue()
        {
            dropChooseCategory.dropDownSelectByValue("65");
            txtSummary.typeText("Teste 003");
            txtDescription.typeText("Teste com caractere é$p&ç;ãl");
            radioPrivate.click();
            btnSubmitReport.Click();

            return new MyViewPage();
        }
    }
}
