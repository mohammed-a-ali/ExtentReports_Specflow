using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TechTalk.SpecFlow;

namespace ExtentReport.support
{
    [Binding]
    public sealed class Hooks
    {
        // For additional details on SpecFlow hooks see http://go.specflow.org/doc-hooks

        //Open the browser before excute Feature File
        [BeforeFeature]
        public static void OpenBrowser()
        {
            Browser.Intitialize();
        }

        //Close the browser after finishing Feature file execuation
        [AfterFeature]
        public static void AfterFeature()
        {
            Browser.Close();
        }
    }
}
