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
    public class Workflow_3
    {
        private IWebDriver driver;
        private WebDriverWait wait;

        private string baseUrl = "https://parabank.parasoft.com/parabank/index.htm";
        private string username = "john";  // înlocuiește cu userul tău
        private string password = "demo";  // înlocuiește cu parola ta

        [TestInitialize]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/index.htm");
        }

        [TestMethod]
        public void UpdateContactInformationTest()
        {
            var loginPage = new LoginPage(driver);
            var updateInfoPage = new UpdateInfoPage(driver);

            loginPage.GoToLoginPage();
            loginPage.Login("john", "demo");

            updateInfoPage.GoToUpdateContactPage();
            updateInfoPage.UpdateContactInformation(
                "New Address St 100",
                "New City",
                "NewState",
                "54321",
                "0789123456"
            );

            Assert.IsTrue(driver.PageSource.Contains("Your updated address and phone number have been added to the system."),
                "contact update message not found");
        }


        //[TestCleanup]
        //public void Cleanup()
        //{
        //    driver.Quit();
        //}
    }
}
