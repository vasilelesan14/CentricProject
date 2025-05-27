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

namespace CentricUnitTestProject
{
    [TestClass]
    public class Flow1_LoginLogout
    {
        private IWebDriver _driver;
        private ResourceManager _resManager;
        private string _generatedUsername;

        [TestInitialize]
        public void Setup()
        {
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize();
            _resManager = new ResourceManager("CentricUnitTestProject.Date.UserData", Assembly.GetExecutingAssembly());

        }

        [TestMethod]
        public void Test_Register()
        {
            var registerPage = new RegisterPage(_driver);

            registerPage.GoToRegisterPage();
            registerPage.FillRegisterForm(
                UserData.FirstName,
                UserData.LastName,
                UserData.Adress,
                UserData.City,
                UserData.State,
                UserData.ZipCode,
                UserData.Phone,
                UserData.SSN,
                UserData.UserName,
                UserData.Password
                );

            Assert.IsTrue(_driver.PageSource.Contains("Your account was created successfully"), "account creation failed");
        }

        [TestCleanup]
        public void TearDown()
        {
            _driver.Quit();
        }
    }

}
