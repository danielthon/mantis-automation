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
            ReportPage repo = main.GoToReportIssue();
            main = repo.CadastrarIssue();
        }
    }
}
