using Componente.Exceptions;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Componente.Comum
{
    public static class Utils
    {
        internal static IWebElement findElement(By by)
        {
            try
            {
                return SeleniumWebDriver.Driver.FindElement(by).moveToElement();
            }
            catch (Exception e)
            {
                throw new NoSuchElementException($"Não foi possível encontrar o elemento de {by.ToString()}. | \"{e.Message}\"");
            }
        }
        internal static IWebElement findElement(this IWebElement elemento, By by)
        {
            try
            {
                return elemento.FindElement(by).moveToElement();
            }
            catch (Exception e)
            {
                throw new NoSuchElementException($"Não foi possível encontrar o elemento de {by.ToString()}. | \"{e.Message}\"");
            }
        }
        internal static IWebElement moveToElement(this IWebElement elemento)
        {
            Actions actions = new Actions(SeleniumWebDriver.Driver);
            actions.MoveToElement(elemento).Perform();
            return elemento;
        }


        internal static void typeText(this IWebElement elemento, string entrada)
        {
            if (!elemento.Displayed)
                throw new ElementNotVisibleException($"'{elemento.TagName}' (class={elemento.GetCssValue("class")}) foi encontrada na página, mas não está visível/acessível.");

            elemento.Clear();
            elemento.SendKeys(entrada);
        }
        internal static void click(this IWebElement elemento)
        {
            try
            {
                elemento.Click();
            }
            catch (Exception e)
            {
                if (e is ElementClickInterceptedException || e is ElementNotInteractableException)
                {
                    try
                    {
                        ((IJavaScriptExecutor)SeleniumWebDriver.Driver).ExecuteScript("arguments[0].click();", elemento);
                    }
                    catch
                    {
                        throw e;
                    }
                }
                else
                    throw e;
            }
        }
        internal static void dropDownSelectByText(this IWebElement elemento, string opcao)
        {
            try
            {
                (new SelectElement(elemento)).SelectByText(opcao);
            }
            catch
            {
                throw new NoSuchElementException($"Não foi possível encontrar a opção '{opcao}'");
            }
        }
        internal static void dropDownSelectByValue(this IWebElement elemento, string opcao)
        {
            try
            {
                (new SelectElement(elemento)).SelectByValue(opcao);
            }
            catch
            {
                throw new NoSuchElementException($"Não foi possível encontrar a opção '{opcao}'");
            }
        }


        public static void assert(string esperado, string exibido)
        {
            if (esperado != exibido)
                throw new AssertionException(esperado, exibido);
        }


        public static string saveScreenshot(string nomeArquivo)
        {
            Screenshot print = ((ITakesScreenshot)SeleniumWebDriver.Driver).GetScreenshot();

            string endereco = $@"{Relatorios.Relatorio.enderecoSaida}Screenshots";
            string enderecoImagem = $@"{endereco}\{nomeArquivo}.png";

            if (!Directory.Exists(endereco))
                Directory.CreateDirectory(endereco);

            print.SaveAsFile(enderecoImagem, ScreenshotImageFormat.Png);

            return enderecoImagem;
        }
    }
}
