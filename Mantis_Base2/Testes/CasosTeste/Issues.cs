using NUnit.Framework;
using Componente.PageObjects;
using Dados.DataObjects;
using Dados;
using System.Collections.Generic;
using Relatorios;
using NUnit.Framework.Interfaces;

namespace Testes.CasosTeste
{
    [TestFixture]
    public class Issues
    {
        public List<Login> logins = Conexao.GetDadosCsv<Login>();
        public List<Issue> issues = Conexao.GetDadosCsv<Issue>();


        [Test]
        [TestCase(TestName = "Report new issue and verify")]
        public void T001()
        {
            MyViewPage main = new MyViewPage(logins[0]);
            ReportPage repo = main.GoToReportIssue(logins[0]);
            ViewIssuesPage viewi = repo.CadastrarIssue(issues[0]);

            ViewPage view = viewi.SearchAndAccess(issues[0]);
            view.VerificarIssue(issues[0]);
        }

        [Test]
        [TestCase(TestName = "Add, edit and delete note from issue")]
        public void T002()
        {
            MyViewPage main = new MyViewPage(logins[0]);
            //incompleto
        }


        [SetUp]
        public void TestSetUp()
        {
            string nomeFixture = TestContext.CurrentContext.Test.ClassName;
            string nomeTest = TestContext.CurrentContext.Test.MethodName;
            string descricaoTest = TestContext.CurrentContext.Test.Name;

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
