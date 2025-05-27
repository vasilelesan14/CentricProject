using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using CentricUnitTestProject.PageObjectModel;
using CentricUnitTestProject.Date;
using System.Resources;
using System.Reflection;
using System;
using OpenQA.Selenium.Support.UI;
using System.Threading;
using CentricUnitTestProject.PageObjectModel;

namespace CentricUnitTestProject.Tests
{
    [TestClass]

    public class Workflow_2
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
        }

        [TestMethod]
        public void OpenNewSavingsAccount()
        {
            var loginPage = new LoginPage(driver);
            var openAccountPage = new OpenAccountPage(driver);

            loginPage.GoToLoginPage();
            loginPage.Login("john", "demo");

            openAccountPage.GoToOpenAccountPage();
            openAccountPage.OpenNewAccount("SAVINGS", "13344");
            Thread.Sleep(500);

            var accountId = openAccountPage.GetNewAccountId();
            Assert.IsFalse(string.IsNullOrEmpty(accountId), "new account id not generated");
        }

        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
