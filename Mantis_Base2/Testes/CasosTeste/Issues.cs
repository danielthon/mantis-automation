using NUnit.Framework;
using Componente.PageObjects;

namespace Testes.CasosTeste
{
    [TestFixture]
    public class Issues
    {
        [Test]
        [TestCase(TestName = "Só vê se funciona")]
        public void T001()
        {
            LoginPage login = new LoginPage();
            login.FazerLogin();
        }
    }
}
