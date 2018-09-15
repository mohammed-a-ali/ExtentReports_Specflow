using System;
using TechTalk.SpecFlow;
using ExtentReport.support;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using NUnit.Framework;
using System.Threading;

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
                IWebElement Tab = Browser.webdriver.FindElement(By.XPath($"//span[text()='{tab}']"));
                Tab.Click();
        }


        [Given(@"I select ""(.*)"" trip")]
        public void GivenISelectTrip(string option)
        {
            IWebElement TripType = Browser.webdriver.FindElement(By.XPath($"//input[@type='radio']/../../label[text()='{option}']"));
            Browser.Wait(5);
            TripType.Click();
        }


        [Given(@"I selected (From|To) ""(.*)""")]
        public void GivenISelectedFrom(string trip, string dest)
        {
            IWebElement tripDest = Browser.webdriver.FindElement(By.XPath($"//label[text()='{trip}']/..//input[@type='text']"));
            tripDest.Clear();
            Browser.Wait(5);
            tripDest.SendKeys(dest);
        }

        [Given(@"I select (Depart|Return) date ""(.*)""")]
        public void GivenISelectDepartDate(string destDate,string date)
        {
            IWebElement tripDest = Browser.webdriver.FindElement(By.XPath($"//label[text()='{destDate}']/..//input[@type='text']"));
            tripDest.Clear();
            tripDest.SendKeys(date);
            Browser.Wait(5);
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

        [When(@"I press on ""(.*)"" button")]
        public void WhenIPressSearchFlights(string button)
        {
            IWebElement search = Browser.webdriver.FindElement(By.XPath($"//button[text()='{button}']"));
            search.Click();
            Browser.Wait(10);
        }


        [Then(@"I should see ""(.*)""")]
        public void ThenIShouldSee(string text)
        {
            string val = Browser.webdriver.FindElement(By.XPath($"//*[contains(text(),'{text}')]")).Text;
            Assert.AreEqual(val, text);
        }

        [When(@"I wait (.*) seconds")]
        public void WhenIWaitSeconds(int number)
        {
            Thread.Sleep(number * 1000);
        }
    }
}
