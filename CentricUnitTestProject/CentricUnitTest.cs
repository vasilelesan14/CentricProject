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
        private WebDriverWait wait;


        [TestInitialize]
        public void Init()
        {
            try
            {
                driver = new ChromeDriver();
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl("https://testautomationu.applitools.com/");
                wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            }
            catch (Exception ex)
            {
                Console.WriteLine("Setup failed: " + ex.Message);
                throw;
            }
        }

        [TestMethod]
        public void TestValidLogin()
        {
            driver.Navigate().GoToUrl("https://testautomationu.applitools.com/login");

            // Click pe butonul Sign in with email
            var signInEmailBtn = wait.Until(d => d.FindElement(By.CssSelector("li.firebaseui-list-item button.firebaseui-idp-password")));
            signInEmailBtn.Click();

            // Așteaptă câmpul de email (input cu id="email") și introdu emailul
            var emailInput = wait.Until(d => d.FindElement(By.CssSelector("#firebaseui-auth-container > div > form > div.firebaseui-card-content > div.firebaseui-textfield.mdl-textfield.mdl-js-textfield.mdl-textfield--floating-label.is-dirty.is-upgraded > input")));
            emailInput.SendKeys("vasile.lesan@student.tuiasi.ro");

            // Trimite Enter sau da click pe Next dacă există (depinde de flux)
            emailInput.SendKeys(Keys.Enter);

            // Așteaptă să apară câmpul de parolă (input cu id="password") după ce ai introdus emailul
            var passwordInput = wait.Until(d => d.FindElement(By.CssSelector("#firebaseui-auth-container > div > form > div.firebaseui-card-content > div:nth-child(3) > input")));
            passwordInput.SendKeys("vasile1234!");

            // Trimite formularul apăsând Enter
            passwordInput.SendKeys(Keys.Enter);

            // Așteaptă elementul care confirmă loginul reușit
            var navbarBrand = wait.Until(d => d.FindElement(By.ClassName("navbar-brand")));
            Assert.IsTrue(navbarBrand.Displayed, "Login eșuat - navbar brand nu este vizibil!");
        }

            [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
        }
    }
}
