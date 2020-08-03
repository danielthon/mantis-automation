using NUnit.Framework;
using Componente.PageObjects;
using Dados.DataObjects;
using Dados;
using System.Collections.Generic;
using Relatorios;
using NUnit.Framework.Interfaces;
using System;
using Componente.Comum;

namespace Testes.CasosTeste
{
    [TestFixture]
    public class Issues
    {
        private static string nomeFixture { get { return TestContext.CurrentContext.Test.ClassName; } }
        private static string nomeTest { get { return TestContext.CurrentContext.Test.MethodName; } }
        private static string descricaoTest { get { return TestContext.CurrentContext.Test.Name; } }


        public List<Login> logins = Conexao.getDadosCsv<Login>();
        public List<Issue> issues = Conexao.getDadosCsv<Issue>();


        [Test]
        [TestCase(TestName = "Report new issue and verify")]
        public void T001()
        {
            try
            {
                var myView = new MyViewPage(logins[0]);
                var reportIssue = myView.GoToReportIssue(logins[0]);
                var viewIssues = reportIssue.CadastrarIssue(issues[0]);

                var view = viewIssues.SearchAndAccess(issues[0]);
                view.VerificarIssue(issues[0]);
            }
            catch (Exception e)
            {
                Relatorio.addLog(e, Utils.saveScreenshot($"{nomeFixture}_{nomeTest}"));
            }
        }

        [Test]
        [TestCase(TestName = "Add, edit and delete note from issue")]
        public void T002()
        {
            try
            {
                var myView = new MyViewPage(logins[0]);
                var viewIssues = myView.GoToViewIssues();
                var view = viewIssues.SearchAndAccess(issues[1]);
                
                view.AdicionarNote("nota NOVA com caractere é$p&çiãl");
                view.VerificarNote(2, "nota NOVA com caractere é$p&çiãl");

                view.EditarNote(2, "nota ANTIGA com caractere é$p&çiãl");
                view.VerificarNote(2, "nota ANTIGA com caractere é$p&çiãl");

                view.ExcluirNote(2);
                view.VerificarExclusaoNote("nota ANTIGA com caractere é$p&çiãl");
            }
            catch (Exception e)
            {
                Relatorio.addLog(e, Utils.saveScreenshot($"{nomeFixture}_{nomeTest}"));
            }
        }


        [SetUp]
        public void TestSetUp()
        {
            Relatorio.preTeste(nomeFixture.Substring(nomeFixture.LastIndexOf('.') + 1), nomeTest, descricaoTest);
        }
        [TearDown]
        public void TestTearDown()
        {
            switch (TestContext.CurrentContext.Result.Outcome.Status)
            {
                case TestStatus.Passed: Relatorio.posTeste(Status.Pass); break;
                case TestStatus.Failed: Relatorio.posTeste(Status.Fail); break;
                default: Relatorio.posTeste(Status.Warning); break;
            }
        }
    }
}
