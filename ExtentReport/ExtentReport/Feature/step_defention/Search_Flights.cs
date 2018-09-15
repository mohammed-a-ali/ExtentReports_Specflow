using System;
using TechTalk.SpecFlow;
using ExtentReport.support;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;

namespace ExtentReport
{
    [Binding]
    public class Search_Flights
    {
        [Given(@"I am on the Homepage")]
        public void GivenIAmOnTheHomepage()
        {
            Browser.visit(Browser.BaseURL);
        }

        [Given(@"I selected ""(.*)"" tab")]
        public void GivenISelectedTab(string tab)
        {
            string PageURL = Browser.webdriver.Url;
            if (PageURL != Browser.BaseURL)
            {
                IWebElement FlightsTab = Browser.webdriver.FindElement(By.XPath("//*[@id='airli']/span"));
                FlightsTab.Click();
            }
        }


        [Given(@"I select ""(.*)"" trip")]
        public void GivenISelectTrip(string p0)
        {
            IWebElement TripType = Browser.webdriver.FindElement(By.XPath("//*[@id='flights-search-controls-root']/div/div/form/div[1]/div/label[2]"));
            TripType.Click();
        }


        [Given(@"I selected from ""(.*)""")]
        public void GivenISelectedFrom(string p0)
        {
            IWebElement From = Browser.webdriver.FindElement(By.Id("origin-fsc-search"));
            if (From.Text != "")
            {
                From.Clear();
            }
            From.SendKeys("Cairo (CAI)");
        }

        [Given(@"I selected to ""(.*)""")]
        public void GivenISelectedTo(string p0)
        {
            IWebElement To = Browser.webdriver.FindElement(By.Id("destination-fsc-search"));
            if (To.Text != "")
            {
                To.Clear();
            }
            To.SendKeys("Riyadh (RUH)");
        }

        [Given(@"I select travellers ""(.*)""")]
        public void GivenISelectTravellers(string p0)
        {
            IWebElement Class = Browser.webdriver.FindElement(By.Id("fsc-class-travellers-trigger-1PZXn"));
            Class.Click();
            IWebElement ChildrenCount = Browser.webdriver.FindElement(By.Id("search-controls-children-nudger"));
            IWebElement ChildrenIncrease = Browser.webdriver.FindElement(By.XPath("//*[@id='cabin-class-travellers-popover']/div/div/div[2]/div/button[2]"));
            ChildrenIncrease.Click();
            ChildrenIncrease.Click();
            Browser.Wait(2);
            
            //Select first Child Age
            IWebElement firstage = Browser.webdriver.FindElement(By.Id("children-age-dropdown-0"));
            firstage.Click();
            Browser.Wait(1);
            SelectElement slectage1 = new SelectElement(firstage);
            slectage1.SelectByValue("0");

            //Select second Child Age
            IWebElement secage = Browser.webdriver.FindElement(By.Id("children-age-dropdown-1"));
            secage.Click();
            Browser.Wait(1);
            SelectElement slectage2 = new SelectElement(secage);
            slectage2.SelectByValue("15");

            //Decrease count to 2
            IWebElement ChildrenDecrease = Browser.webdriver.FindElement(By.XPath("//*[@id='cabin-class-travellers-popover']/div/div/div[2]/div/button[1]"));
            ChildrenDecrease.Click();
            Browser.Wait(1);
            //Click Done button
            IWebElement Done = Browser.webdriver.FindElement(By.XPath("//*[@id='cabin-class-travellers-popover']/footer/button"));
            Done.Click();
        }

        [When(@"I press Search Flights ""(.*)""")]
        public void WhenIPressSearchFlights(string p0)
        {
            IWebElement search = Browser.webdriver.FindElement(By.XPath("//*[@id='flights-search-controls-root']/div/div/form/div[3]/button"));
            search.Click();
        }


        [Then(@"all available flights ""(.*)"" will appear")]
        public void ThenAllAvailableFlightsWillAppear(string p0)
        {
            IWebElement el = Browser.webdriver.FindElement(By.XPath("//*[@id='flights-search-summary-root']/div/section/div[2]/div/p[2]/span"));
            string travellers = el.Text;
            Assert.AreEqual("3 travellers", travellers);
        }
    }
}
