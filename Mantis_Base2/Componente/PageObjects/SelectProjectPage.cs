using Componente.Comum;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Componente.PageObjects
{
    public class SelectProjectPage
    {
        internal static string Url { get { return "login_select_proj_page.php"; } }

        internal IWebElement dropChooseProject => Utils.findElement(By.CssSelector("form[action='set_project.php'] select[name='project_id']"));
        internal IWebElement btnSelectProject => Utils.findElement(By.CssSelector("form[action='set_project.php'] input[type='submit']"));

        public SelectProjectPage() { }

        public ReportPage SelecionarProjeto(string nomeProjeto)
        {
            dropChooseProject.dropDownSelectByText(nomeProjeto);
            btnSelectProject.click();

            return new ReportPage();
        }
        public ReportPage SelecionarProjetoId(string idProjeto)
        {
            dropChooseProject.dropDownSelectByValue(idProjeto);
            btnSelectProject.click();

            return new ReportPage();
        }
    }
}
