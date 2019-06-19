using System;
using System.IO;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Tests
{
    public class Tests
    {
        string ROOT_PATH = Path.GetFullPath(@"../../../../");
        IWebDriver driver;
        WebDriverWait wait;

        [SetUp]
        public void BeforeEach()
        {
            var options = new ChromeOptions();
            options.AddArgument("--start-maximized");
            driver = new ChromeDriver(ROOT_PATH + "/_drivers", options);
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        [TearDown]
        public void AfterEach() { driver.Quit(); }

        [Test]
        public void Test1()
        {
            driver.Url = "https://google.com";
            Assert.That(driver.Title.Contains("Google"));
        }

        [Test]
        public void Test2()
        {
            driver.Url = "https://copart.com";
            driver.FindElement(By.Id("input-search")).SendKeys("exotics" + Keys.Enter);
            // driver.FindElement(By.CssSelector("[ng-click=`search()`]")).Click();

            wait.Until(drvr => drvr.FindElement(By.Id("serverSideDataTable")).Displayed);

            Assert.That(driver.PageSource.Contains("PORSCHE"));

        }



    }
}