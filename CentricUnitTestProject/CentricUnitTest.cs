using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;
using OpenQA.Selenium.Support.UI;

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
                driver.Navigate().GoToUrl("https://www.trivago.ro");

                Thread.Sleep(3000);
                /*                var cookieBtn = driver.FindElement(By.CssSelector("button[data-testid='uc-accept-all-button']"));
                                if (cookieBtn.Displayed)
                                    cookieBtn.Click();*/

                // Obține shadow root
                IWebElement usercentricsRoot = driver.FindElement(By.CssSelector("div.usercentrics-root"));

                // Cast la IJavaScriptExecutor
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

                // Obține shadow root din elementul găsit
                IWebElement shadowRoot = (IWebElement)js.ExecuteScript("return arguments[0].shadowRoot", usercentricsRoot);

                // Caută butonul în shadow root
                IWebElement button = shadowRoot.FindElement(By.CssSelector("button[data-testid='uc-privacy-button']"));

                // Click pe buton
                button.Click();



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
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var searchBox = wait.Until(drv => drv.FindElement(By.CssSelector("input[name='query']")));
            searchBox.Clear();
            searchBox.SendKeys("Paris");

            Thread.Sleep(2000);  // poți înlocui cu un wait mai inteligent

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
