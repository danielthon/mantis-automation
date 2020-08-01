using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using System;
using System.IO;

namespace Relatorios
{
    public enum Status
    {
        Pass,
        Fail,
        Fatal,
        Error,
        Warning,
        Info,
        Skip,
        Debug
    }

    public static class Relatorio
    {
        private static ExtentTest sequenciaAtual;
        private static AventStack.ExtentReports.ExtentReports relatorio;

        public static string PrepararRelatorio()
        {
            string enderecoSaida = AppContext.BaseDirectory + $@"\RELATORIOS\Run_{DateTime.Now.ToString("yyyyMMdd_hhmmss")}\";
            Directory.CreateDirectory(enderecoSaida);

            var html = new ExtentHtmlReporter(enderecoSaida);
            //html.LoadConfig(AppContext.BaseDirectory + @"\extent-config.xml");
            html.Config.ReportName = "mantis-automation";

            relatorio = new AventStack.ExtentReports.ExtentReports();
            relatorio.AttachReporter(html);

            return enderecoSaida;
        }
        public static void FinalizarRelatorio()
        {
            relatorio.Flush();
        }

        public static void PreTeste(string nomeFixture, string nomeTest, string descricaoTest)
        {
            sequenciaAtual = relatorio.CreateTest($"{nomeFixture}.{nomeTest}", descricaoTest);
            sequenciaAtual.AssignCategory(nomeFixture);

            
        }
        public static void PosTeste(Relatorios.Status status)
        {
            switch(status)
            {
                case Status.Pass:
                    AddLog(Status.Pass, "Teste finalizado com sucesso"); break;
                case Status.Fail:
                    AddLog(Status.Fail, "Não foi possível concluir o teste"); break;
                default:
                    AddLog(Status.Warning, "Não foi possível concluir o teste por motivo desconhecido"); break;
            }
        }

        public static void AddLog(Relatorios.Status status, string descricao)
        {
            sequenciaAtual.Log((AventStack.ExtentReports.Status)(int)status, descricao);
            Console.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff")} - {descricao}");
        }
        public static void AddLog(Exception ex, string enderecocreenshot)
        {
            sequenciaAtual.Log((AventStack.ExtentReports.Status)(int)Status.Debug, $"<pre>{ex.StackTrace}</pre>");
            sequenciaAtual.Log((AventStack.ExtentReports.Status)(int)Status.Fail, ex.Message + $"<br><img data-featherlight=\"{enderecocreenshot}\" class=\"step-img\" src=\"{enderecocreenshot}\" data-src=\"{enderecocreenshot}\" width=\"200\">");
            Console.WriteLine($"{DateTime.Now.ToString("yyyy/MM/dd hh:mm:ss.fff")} - {ex.Message}");
        }
    }
}
