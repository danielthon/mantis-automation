using Componente.Comum;
using Dados.DataObjects;
using OpenQA.Selenium;
using Relatorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Componente.PageObjects
{
    public class SelectProjectPage : CommonPage
    {
        internal static string Url { get { return "login_select_proj_page.php"; } }

        internal IWebElement dropChooseProject => Utils.findElement(By.CssSelector("form[action='set_project.php'] select[name='project_id']"));
        internal IWebElement btnSelectProject => Utils.findElement(By.CssSelector("form[action='set_project.php'] input[type='submit']"));

        public SelectProjectPage() { }

        public ReportPage SelecionarProjetoId(Login login)
        {
            dropChooseProject.dropDownSelectByValue(login.ProjetoId);

            Relatorio.addLog(Status.Info, $"Página {Url} acessada");

            btnSelectProject.click();
            var repo = new ReportPage(login);

            Relatorio.addLog(Status.Pass, $"Projeto '{login.ProjetoId}' encontrado e selecionado");

            return repo;
        }
    }
}
