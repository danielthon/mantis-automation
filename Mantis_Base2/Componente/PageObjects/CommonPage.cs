﻿using Componente.Comum;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Componente.PageObjects
{
    public class CommonPage
    {
        internal IWebElement spanLogin => Utils.findElement(By.CssSelector("td[class=login-info-left]>span:first-child"));

        internal IWebElement btnMyView => Utils.findElement(By.CssSelector("td[class=menu]>a:nth-child(1)"));
        internal IWebElement btnViewIssues => Utils.findElement(By.CssSelector("td[class=menu]>a:nth-child(2)"));
        internal IWebElement btnReportIssue => Utils.findElement(By.CssSelector("td[class=menu]>a:nth-child(3)"));
        internal IWebElement btnLogout => Utils.findElement(By.CssSelector("td[class=menu]>a:last-child"));

        public ViewIssuesPage GoToViewIssues()
        {
            btnViewIssues.click();

            return new ViewIssuesPage();
        }
        public ReportPage GoToReportIssue()
        {
            btnReportIssue.click();

            return new ReportPage();
        }
    }
}
