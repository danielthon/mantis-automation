using NUnit.Framework;
using Componente.Comum;
using Relatorios;

namespace Testes
{
    [SetUpFixture]
    public static class SetUp
    {
        [OneTimeSetUp]
        public static void GlobalSetUp()
        {
            Relatorio.prepararRelatorio();

            SeleniumWebDriver.IniciarDriver(
                TestContext.Parameters.Get("browser", "chrome")
                );
            SeleniumWebDriver.URLRaiz = "https://mantis-prova.base2.com.br/";
            SeleniumWebDriver.GoToURL();
        }

        [OneTimeTearDown]
        public static void GlobalTearDown()
        {
            SeleniumWebDriver.FinalizarDriver();

            Relatorio.finalizarRelatorio();
        }
    }
}
