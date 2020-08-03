using Componente.Comum;
using Componente.Exceptions;
using Dados.DataObjects;
using OpenQA.Selenium;
using RazorEngine.Compilation.ImpromptuInterface.Optimization;
using Relatorios;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
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

        internal IWebElement txtNote => Utils.findElement(By.Name("bugnote_text"));
        internal IWebElement btnAddNote => Utils.findElement(By.CssSelector("input[type='submit'][value='Add Note']"));

        private static IWebElement noteOnGrid(int i) => Utils.findElement(By.XPath($@"//tr[@class='bugnote'][{i}]"));
        internal static IWebElement txtNoteOnGrid(int i) => noteOnGrid(i).findElement(By.CssSelector("[class*='bugnote-note']"));
        internal static IWebElement btnEditNoteOnGrid(int i) => noteOnGrid(i).findElement(By.CssSelector("input[type='submit'][value='Edit']"));
        internal static IWebElement txtEditNote => Utils.findElement(By.Name("bugnote_text"));
        internal static IWebElement btnUpdateInformation => Utils.findElement(By.CssSelector("input[type='submit'][value='Update Information']"));
        internal static IWebElement btnDeleteNoteOnGrid(int i) => noteOnGrid(i).findElement(By.CssSelector("input[type='submit'][value='Delete']"));
        internal static IWebElement btnDeleteNote => Utils.findElement(By.CssSelector("input[type='submit'][value='Delete Note']"));


        public ViewPage()
        {
            tdCategory.moveToElement();
            Relatorio.addLog(Status.Info, $"Página {Url} acessada");
        }

        public void VerificarIssue(Issue issue)
        {
            Utils.assert(issue.Category, tdCategory.Text);
            Utils.assert(issue.ViewStatus, tdViewStatus.Text);
            Utils.assert(issue.Summary, tdSummary.Text.Replace($"{issue.Id}: ", ""));
            Utils.assert(issue.Description, tdDescription.Text);

            Relatorio.addLog(Status.Pass, $"Campos da Issue verificados");
        }

        public void AdicionarNote(string descricao)
        {
            txtNote.typeText(descricao);
            btnAddNote.click();

            Relatorio.addLog(Status.Pass, "Note adicionada");
        }
        public void EditarNote(int i, string descricao)
        {
            btnEditNoteOnGrid(i).click();
            txtEditNote.typeText(descricao);
            btnUpdateInformation.click();

            new ViewPage();

            Relatorio.addLog(Status.Pass, "Note editada");
        }
        public void ExcluirNote(int i)
        {
            btnDeleteNoteOnGrid(i).click();
            btnDeleteNote.click();

            new ViewPage();

            Relatorio.addLog(Status.Pass, "Note excluída");
        }

        public void VerificarNote(int i, string descricao)
        {
            Utils.assert(descricao, txtNoteOnGrid(i).Text);

            Relatorio.addLog(Status.Pass, "Texto da Note verificado");
        }
        public void VerificarExclusaoNote(string descricao)
        {
            try
            {
                Utils.findElement(By.XPath($@"//td[contains(text(), '{descricao}')]"));
                throw new Exception("Note excluída encontrada em tela");
            }
            catch (NoSuchElementException)
            {
                Relatorio.addLog(Status.Pass, "Note não encontrada, com sucesso");
            }
            catch (Exception e)
            {
                throw e;
            }
        }


        public ViewIssuesPage Voltar()
        {
            SeleniumWebDriver.GoBack();
            return new ViewIssuesPage();
        }
    }
}
