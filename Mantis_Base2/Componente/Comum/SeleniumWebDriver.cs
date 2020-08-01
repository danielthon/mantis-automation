using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Text;

namespace Componente.Comum
{
    public enum Browser
    {
        Chrome = 1,
        Firefox = 2
    }

    public static class SeleniumWebDriver
    {
        private static IWebDriver driver;
        internal static IWebDriver Driver {  get { return driver; } }

        private static string EnderecoDrivers { get { return AppContext.BaseDirectory + @"\Drivers\"; } }
        public static string URLRaiz { get; set; }
        public static string URLAtual { get { return Driver.Url; } }

        public static void IniciarDriver(string browser)
        {
            try
            {
                IniciarDriver((Browser)Enum.Parse(typeof(Browser), browser, true));
            }
            catch
            {
                IniciarDriver(Browser.Chrome);
            }
        }
        private static void IniciarDriver(Browser browser)
        {
            if (Driver != null)
                FinalizarDriver();

            DriverOptions options;

            switch(browser)
            {
                case Browser.Chrome:
                    options = new ChromeOptions();
                    break;

                case Browser.Firefox:
                    options = new FirefoxOptions();
                    break;

                default:
                    options = null;
                    break;
            }

            switch (options)
            {
                case ChromeOptions chrome:
                    chrome.AddArguments("disable-extensions");
                    driver = new ChromeDriver(EnderecoDrivers, chrome);
                    break;

                case FirefoxOptions fox:
                    fox.AddArguments("disable-extensions");
                    driver = new FirefoxDriver(EnderecoDrivers, fox);
                    break;

                default:
                    driver = null;
                    break;
            }

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
        }

        public static void FinalizarDriver()
        {
            Driver.Quit();
            Driver.Dispose();
            driver = null;
        }

        /// <summary>
        /// Navega para a URL parametrizada. Caso não seja informada, navega para a URL raiz.
        /// </summary>
        /// <param name="url"></param>
        public static void GoToURL(string url = null)
        {
            if(url == null)
                Driver.Navigate().GoToUrl(URLRaiz);
            else
                Driver.Navigate().GoToUrl(url);
        }
        public static void GoBack()
        {
            Driver.Navigate().Back();
        }
    }
}
