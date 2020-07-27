using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
namespace DemoProj
{
    [TestFixture()]
    public class Test
    {
        public IWebDriver driver;
        [Test()]
        public void TestCase()
        {
            driver = new ChromeDriver();
            driver.Manage().Cookies.DeleteAllCookies();

            driver.Url="http://cgross.github.io/angular-busy/demo/";
       

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);

            //Clearing the Delay(ms) text field
            driver.FindElement(By.Id("delayInput")).Clear();
            //Entering the value
            driver.FindElement(By.Id("delayInput")).SendKeys("5");
            driver.FindElement(By.Id("delayInput")).SendKeys(Keys.Enter);
            //Waitng for the spinner
            waitForElement("[class*='cg-busy-default-spinner']");


            //Clearing the Min Duration
            driver.FindElement(By.Id("durationInput")).Clear();
            //Entering the value
            driver.FindElement(By.Id("durationInput")).SendKeys("7");
            driver.FindElement(By.Id("durationInput")).SendKeys(Keys.Enter);
            //Waiting for the Spinner
            if (driver.FindElements(By.CssSelector("[class*='cg-busy-default-spinner']")).Count > 0)
            {
                waitForElement("[class*='cg-busy-default-spinner']");
            }

            //Selecting Template URL
            var education = driver.FindElement(By.Id("template"));
            var selectElement = new SelectElement(education);
            selectElement.SelectByValue("custom-template.html");
            //Selecting Custom-Template
            driver.FindElement(By.CssSelector("[class*='btn btn-default pull-right")).Click();
            //Waiting for the Dancing Wizard
            waitForElement("[class*='cg-busy cg-busy-animation ng-scope ng-hide']");


            //Clearing the Message
            driver.FindElement(By.Id("message")).Clear();
            //Updating the message to 'Waiting'
            driver.FindElement(By.Id("message")).SendKeys("Waiting");


            //Changing the template URL to Standard
            driver.FindElement(By.Id("template")).SendKeys("standard");
            driver.FindElement(By.Id("message")).SendKeys(Keys.Enter);


           // Waiting for the spinner
            if (driver.FindElements(By.CssSelector("[class*='cg-busy-default-spinner']")).Count > 0)
            {
                waitForElement("[class*='cg-busy-default-spinner']");
            }


            //Clearing the Min Duration field
            driver.FindElement(By.Id("durationInput")).Clear();
            //Updating the Min Duration to 1000
            driver.FindElement(By.Id("durationInput")).SendKeys("1000");
            driver.FindElement(By.Id("durationInput")).SendKeys(Keys.Enter);


        }
        public void waitForElement(String locatorValue)
        {

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector(locatorValue)));

        }
    }
    }
