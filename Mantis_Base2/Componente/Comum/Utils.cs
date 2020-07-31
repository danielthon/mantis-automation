using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Componente.Comum
{
    public static class Utils
    {
        internal static IWebElement FindElement(By by)
        {
            try
            {
                return SeleniumWebDriver.Driver.FindElement(by).MoveToElement();
            }
            catch (Exception e)
            {
                throw new NoSuchElementException($"Não foi possível encontrar o elemento de {by.ToString()}. | \"{e.Message}\"");
            }
        }
        internal static IWebElement MoveToElement(this IWebElement elemento)
        {
            Actions actions = new Actions(SeleniumWebDriver.Driver);
            actions.MoveToElement(elemento).Perform();
            return elemento;
        }


        internal static void TypeText(this IWebElement elemento, string entrada)
        {
            if (!elemento.Displayed)
                throw new ElementNotVisibleException($"'{elemento.TagName}' (class={elemento.GetCssValue("class")}) foi encontrada na página, mas não está visível/acessível.");

            elemento.Clear();
            elemento.SendKeys(entrada);
        }
    }
}
