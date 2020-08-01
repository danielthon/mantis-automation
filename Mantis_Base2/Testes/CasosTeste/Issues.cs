using NUnit.Framework;
using Componente.PageObjects;
using Dados.DataObjects;
using Dados;
using System.Collections.Generic;

namespace Testes.CasosTeste
{
    [TestFixture]
    public class Issues
    {
        public List<Login> logins = Conexao.GetDadosCsv<Login>();
        public List<Issue> issues = Conexao.GetDadosCsv<Issue>();

        [Test]
        [TestCase(TestName = "Report issue and verify")]
        public void T001()
        {
            MyViewPage main = new MyViewPage(logins[0]);
            ReportPage repo = main.GoToReportIssue(logins[0]);
            ViewIssuesPage view = repo.CadastrarIssue(issues[0]);

            view.SearchAndVerify(issues[0]);
        }
    }
}
