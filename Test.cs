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

            //var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            //wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("[class*='cg-busy-default-spinner']")));
            // wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("[class*='cg-busy cg-busy-animation ng-scope ng-hide']")));
            waitForElement("[class*='cg-busy-default-spinner']");



            driver.FindElement(By.Id("durationInput")).Clear();
            driver.FindElement(By.Id("durationInput")).SendKeys("7");
            driver.FindElement(By.Id("durationInput")).SendKeys(Keys.Enter);

            //wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("[class*='cg-busy-default-spinner']")));
            // wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("[class*='cg-busy cg-busy-animation ng-scope ng-hide']")));
            if (driver.FindElements(By.CssSelector("[class*='cg-busy-default-spinner']")).Count > 0)
            {
                waitForElement("[class*='cg-busy-default-spinner']");
            }
           // if (driver.FindElements(By.CssSelector("[class*='cg-busy cg-busy-animation ng-scope ng-hide']")).Count > 0)
           // {
           //     waitForElement("[class*='cg-busy cg-busy-animation ng-scope ng-hide']");
           // }
            

            var education = driver.FindElement(By.Id("template"));
          
            var selectElement = new SelectElement(education);

            selectElement.SelectByValue("custom-template.html");

            driver.FindElement(By.CssSelector("[class*='btn btn-default pull-right")).Click();
            // wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("[class*='cg-busy cg-busy-animation ng-scope ng-hide']")));
            waitForElement("[class*='cg-busy cg-busy-animation ng-scope ng-hide']");
            driver.FindElement(By.Id("message")).Clear();
            driver.FindElement(By.Id("message")).SendKeys("Waiting");

          //  selectElement.SelectByValue("Standard");
            driver.FindElement(By.Id("template")).SendKeys("standard");
            driver.FindElement(By.Id("message")).SendKeys(Keys.Enter);

            //  wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("[class*='cg-busy-default-spinner']")));
            //  wait.Until(ExpectedConditions.InvisibilityOfElementLocated(By.CssSelector("[class*='cg-busy cg-busy-animation ng-scope ng-hide']")));
            if (driver.FindElements(By.CssSelector("[class*='cg-busy-default-spinner']")).Count > 0)
            {
                waitForElement("[class*='cg-busy-default-spinner']");
            }
            driver.FindElement(By.Id("durationInput")).Clear();
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

