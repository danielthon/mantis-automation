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
                    ((ChromeOptions)options).AddArguments("disable-extensions");
                    break;

                case Browser.Firefox:
                    options = new FirefoxOptions();
                    ((FirefoxOptions)options).AddArguments("disable-extensions");
                    break;

                default:
                    options = null;
                    break;
            }

            switch (browser)
            {
                case Browser.Chrome:
                    driver = new ChromeDriver(EnderecoDrivers, (ChromeOptions)options);
                    break;

                case Browser.Firefox:
                    driver = new FirefoxDriver(EnderecoDrivers, (FirefoxOptions)options);
                    break;

                default:
                    driver = null;
                    break;
            }

            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(2);
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
    }
}
