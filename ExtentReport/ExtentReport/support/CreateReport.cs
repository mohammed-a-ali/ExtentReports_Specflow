using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using AventStack.ExtentReports.Reporter.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ExtentReport
{
    public static class CreateReport
    {
        public static ExtentReports extent;
        public static ExtentTest extest;

        [OneTimeSetUp]
        public static void Report()
        {
            extent = new ExtentReports();
            var htmlReporter = new ExtentHtmlReporter("C:\\extent.htmls");
            htmlReporter.Configuration().DocumentTitle = "ExtReport";
            htmlReporter.Configuration().Theme = Theme.Dark;

            extent.AttachReporter(htmlReporter);
        }
    }
}
