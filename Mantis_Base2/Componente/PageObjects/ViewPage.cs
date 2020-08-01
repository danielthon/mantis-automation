using Componente.Comum;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Componente.PageObjects
{
    public class ViewPage : CommonPage
    {
        internal IWebElement tdCategory => Utils.findElement(By.CssSelector("table:nth-of-type(3)>tbody>tr:nth-of-type(3)>td:nth-of-type(3)"));
        internal IWebElement tdViewStatus => Utils.findElement(By.CssSelector("table:nth-of-type(3)>tbody>tr:nth-of-type(3)>td:nth-of-type(4)"));
        internal IWebElement tdSummary => Utils.findElement(By.CssSelector("table:nth-of-type(3)>tbody>tr:nth-of-type(11)>td:nth-of-type(2)"));
        internal IWebElement tdDescription => Utils.findElement(By.CssSelector("table:nth-of-type(3)>tbody>tr:nth-of-type(12)>td:nth-of-type(2)"));

        public ViewPage()
        {

        }

        public void VerificarIssue()
        {
            //0003748
            //[All Projects] 7EI2PODHPN
            //Teste 003
            //Teste com caractere é$p&ç;ãl
            //private

            Utils.assert("[All Projects] 7EI2PODHPN", tdCategory.Text);
            Utils.assert("private", tdViewStatus.Text);
            Utils.assert("Teste 003", tdSummary.Text.Replace("0003748: ", ""));
            Utils.assert("Teste com caractere é$p&ç;ãl", tdDescription.Text);
        }
    }
}
