using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace CentricUnitTestProject.PageObjectModel
{
    public class RegisterPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;
        private Random _rand;
        private string _username;
        private string _password;

        public RegisterPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            _rand = new Random();
            _username = "CentricTest" + _rand.Next(14, 99999);
            _password = "test123";
        }

        public void GoToRegisterPage()
        {
            _driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/register.htm");
        }

        public void FillRegisterForm()
        {

            _driver.FindElement(By.Id("customer.firstName")).SendKeys("Test");
            _driver.FindElement(By.Id("customer.lastName")).SendKeys("User");
            _driver.FindElement(By.Id("customer.address.street")).SendKeys("123 Test St");
            _driver.FindElement(By.Id("customer.address.city")).SendKeys("Test City");
            _driver.FindElement(By.Id("customer.address.state")).SendKeys("TS");
            _driver.FindElement(By.Id("customer.address.zipCode")).SendKeys("12345");
            _driver.FindElement(By.Id("customer.phoneNumber")).SendKeys("1234567890");
            _driver.FindElement(By.Id("customer.ssn")).SendKeys("123-45-6789");
            _driver.FindElement(By.Id("customer.username")).SendKeys(_username);
            _driver.FindElement(By.Id("customer.password")).SendKeys(_password);
            _driver.FindElement(By.Id("repeatedPassword")).SendKeys(_password);

            Thread.Sleep(1000);

            var registerBtn = _wait.Until(d => d.FindElement(By.XPath("//input[@value='Register']")));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", registerBtn);

            Thread.Sleep(1000);

            _wait.Until(d => d.FindElement(By.XPath("//*[@id='rightPanel']/h1")));
        }
    }

}
