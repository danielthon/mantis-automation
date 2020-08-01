using NUnit.Framework;
using Componente.PageObjects;

namespace Testes.CasosTeste
{
    [TestFixture]
    public class Issues
    {
        [Test]
        [TestCase(TestName = "Report issue and verify")]
        public void T001()
        {
            MyViewPage main = new MyViewPage();
            //ReportPage repo = main.GoToReportIssue();
            //ViewIssuesPage view = repo.CadastrarIssue();
            ViewIssuesPage view = main.GoToViewIssues();

            view.SearchAndVerify("0003748");
        }
    }
}
