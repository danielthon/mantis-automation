﻿using Componente.Comum;
using Dados.DataObjects;
using OpenQA.Selenium;
using Relatorios;
using System;
using System.Collections.Generic;
using System.Text;

namespace Componente.PageObjects
{
    public class ViewPage : CommonPage
    {
        internal static string Url { get { return "view.php"; } }

        internal IWebElement tdCategory => Utils.findElement(By.CssSelector("table:nth-of-type(3)>tbody>tr:nth-of-type(3)>td:nth-of-type(3)"));
        internal IWebElement tdViewStatus => Utils.findElement(By.CssSelector("table:nth-of-type(3)>tbody>tr:nth-of-type(3)>td:nth-of-type(4)"));
        internal IWebElement tdSummary => Utils.findElement(By.CssSelector("table:nth-of-type(3)>tbody>tr:nth-of-type(11)>td:nth-of-type(2)"));
        internal IWebElement tdDescription => Utils.findElement(By.CssSelector("table:nth-of-type(3)>tbody>tr:nth-of-type(12)>td:nth-of-type(2)"));

        public ViewPage()
        {
            tdCategory.moveToElement();
            Relatorio.AddLog(Status.Info, $"Página {Url} acessada");
        }

        public void VerificarIssue(Issue issue)
        {
            Utils.assert(issue.Category, tdCategory.Text);
            Utils.assert(issue.ViewStatus, tdViewStatus.Text);
            Utils.assert(issue.Summary, tdSummary.Text.Replace($"{issue.Id}: ", ""));
            Utils.assert(issue.Description, tdDescription.Text);

            Relatorio.AddLog(Status.Pass, $"Campos da Issue verificados");
        }

        public ViewIssuesPage Voltar()
        {
            SeleniumWebDriver.GoBack();
            return new ViewIssuesPage();
        }
    }
}
