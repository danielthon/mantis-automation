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


        public List<Login> logins = Conexao.GetDadosCsv<Login>();
        public List<Issue> issues = Conexao.GetDadosCsv<Issue>();


        [Test]
        [TestCase(TestName = "Report new issue and verify")]
        public void T001()
        {
            try
            {
                MyViewPage main = new MyViewPage(logins[0]);
                ReportPage repo = main.GoToReportIssue(logins[0]);
                ViewIssuesPage viewi = repo.CadastrarIssue(issues[0]);

                ViewPage view = viewi.SearchAndAccess(issues[0]);
                view.VerificarIssue(issues[0]);
            }
            catch (Exception e)
            {
                Relatorio.AddLog(e, Utils.saveScreenshot($"{nomeFixture}_{nomeTest}"));
            }
        }

        [Test]
        [TestCase(TestName = "Add, edit and delete note from issue")]
        public void T002()
        {
            try
            {
                MyViewPage main = new MyViewPage(logins[0]);
                //incompleto
            }
            catch (Exception e)
            {
                Relatorio.AddLog(e, Utils.saveScreenshot($"{nomeFixture}_{nomeTest}"));
            }
        }


        [SetUp]
        public void TestSetUp()
        {
            Relatorio.PreTeste(nomeFixture.Substring(nomeFixture.LastIndexOf('.') + 1), nomeTest, descricaoTest);
        }
        [TearDown]
        public void TestTearDown()
        {
            switch (TestContext.CurrentContext.Result.Outcome.Status)
            {
                case TestStatus.Passed: Relatorio.PosTeste(Status.Pass); break;
                case TestStatus.Failed: Relatorio.PosTeste(Status.Fail); break;
                default: Relatorio.PosTeste(Status.Warning); break;
            }
        }
    }
}
