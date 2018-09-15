using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;

namespace ExtentReport.support
{
    class Browser
    {
        public static IWebDriver webdriver;
        public static string BaseURL = "https://www.skyscanner.net/";

        //OPen the Browser and Maximize the Window
        public static void Intitialize()
        {
            webdriver = new ChromeDriver();
            webdriver.Manage().Window.Maximize();
        }

        //Go to the testing site link
        public static void visit (string URL)
        {
            webdriver.Navigate().GoToUrl(URL);
        }

        //Close the Browser
        public static void Close()
        {
            webdriver.Close();
        }

        //Wait Time
        public static void Wait(int time)
        {
            WebDriverWait wait = new WebDriverWait(webdriver, TimeSpan.FromSeconds(time));
        }
    }
}
