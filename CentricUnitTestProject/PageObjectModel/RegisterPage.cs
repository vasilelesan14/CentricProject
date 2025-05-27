using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace CentricUnitTestProject.PageObjectModel
{
    public class RegisterPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public RegisterPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void GoToRegisterPage()
        {
            _driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/register.htm");
        }

        public void FillRegisterForm(string firstName, string lastName, string address, string city, string state, string zipCode, string phone, string ssn, string username, string password)
        {
            _wait.Until(d => d.FindElement(By.Id("customer.firstName"))).SendKeys(firstName);
            _driver.FindElement(By.Id("customer.lastName")).SendKeys(lastName);
            _driver.FindElement(By.Id("customer.address.street")).SendKeys(address);
            _driver.FindElement(By.Id("customer.address.city")).SendKeys(city);
            _driver.FindElement(By.Id("customer.address.state")).SendKeys(state);
            _driver.FindElement(By.Id("customer.address.zipCode")).SendKeys(zipCode);
            _driver.FindElement(By.Id("customer.phoneNumber")).SendKeys(phone);
            _driver.FindElement(By.Id("customer.ssn")).SendKeys(ssn);
            _driver.FindElement(By.Id("customer.username")).SendKeys(username);
            _driver.FindElement(By.Id("customer.password")).SendKeys(password);
            _driver.FindElement(By.Id("repeatedPassword")).SendKeys(password);

            var registerBtn = _wait.Until(d => d.FindElement(By.XPath("//input[@value='Register']")));
            ((IJavaScriptExecutor)_driver).ExecuteScript("arguments[0].click();", registerBtn);

            _wait.Until(d => d.FindElement(By.XPath("//h1[text()='Welcome']")));
        }
    }

}
