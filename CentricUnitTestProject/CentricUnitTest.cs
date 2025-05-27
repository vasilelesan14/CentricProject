using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System.Threading;
using OpenQA.Selenium.Chrome;

namespace ParaBankTests
{
    [TestClass]
    public class LoginTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
        }

        [TestMethod]
        public void ValidLogin_ShouldNavigateToAccountsOverview()
        {
            // Introducere username și password
            driver.FindElement(By.Name("username")).SendKeys("john");
            driver.FindElement(By.Name("password")).SendKeys("demo");
            driver.FindElement(By.XPath("//input[@value='Log In']")).Click();
            Thread.Sleep(10);

            // Verificare că pagina "Accounts Overview" este afișată
            Assert.IsTrue(driver.PageSource.Contains("Accounts Overview"), "Autentificarea a eșuat sau pagina nu a fost încărcată corect.");
        }

        [TestCleanup]
        public void Teardown()
        {
            driver.Quit();
        }
    }
}
