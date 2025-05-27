using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

namespace CentricUnitTestProject
{
    [TestClass]
    public class CentricUnitTest
    {

        private IWebDriver driver;

        [TestInitialize]
        public void Init()
        {
            try
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Setup failed: " + ex.Message);
                throw;
            }
        }

        [TestMethod]
        public void SearchForParis_ShouldDisplayResults()
        {
            driver.Navigate().GoToUrl("https://www.trivago.com/en-US");

            var searchBox = driver.FindElement(By.CssSelector("input[name='sQuery']"));
            searchBox.SendKeys("Paris");

            Thread.Sleep(2000); 

            searchBox.SendKeys(Keys.Enter);

            Thread.Sleep(4000); 

            Assert.IsTrue(driver.PageSource.Contains("Paris"), "Rezultatele nu conțin 'Paris'");
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
