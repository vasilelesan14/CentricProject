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

namespace CentricUnitTestProject
{
    [TestClass]
    public class ParaBankRegisterTest
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

        public void Flow1_RegisterLogoutLogin()
        {
            var registerPage = new RegisterPage(driver);
            var loginPage = new LoginPage(driver);

            registerPage.GoToRegisterPage();
            registerPage.FillRegisterForm();

            var msg = wait.Until(d => d.FindElement(By.CssSelector("#rightPanel > p")));
            Assert.IsTrue(msg.Text.Contains("Your account was created successfully"));

            Thread.Sleep(500);
            loginPage.LogOut();
            var loginTitle = wait.Until(d => d.FindElement(By.XPath("//h2[text()='Customer Login']")));
            Assert.IsTrue(loginTitle.Displayed);

            Thread.Sleep(500);
            loginPage.GoToLoginPage();
            loginPage.Login("john", "demo");
            Assert.IsTrue(driver.PageSource.Contains("Accounts Overview"), "Autentificarea a eșuat sau pagina nu a fost încărcată corect.");

        }



        /*[TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }*/
    }

}
