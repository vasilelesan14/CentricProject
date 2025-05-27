using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace CentricUnitTestProject.PageObjectModel
{
    public class UpdateInfoPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public UpdateInfoPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void GoToUpdateContactPage()
        {
            _driver.FindElement(By.LinkText("Update Contact Info")).Click();
            _wait.Until(d => d.FindElement(By.XPath("//h1[text()='Update Profile']")));
        }

        public void UpdateContactInformation(string address, string city, string state, string zipCode, string phone)
        {
            _driver.FindElement(By.Id("customer.address.street")).Clear();
            _driver.FindElement(By.Id("customer.address.street")).SendKeys(address);

            _driver.FindElement(By.Id("customer.address.city")).Clear();
            _driver.FindElement(By.Id("customer.address.city")).SendKeys(city);

            _driver.FindElement(By.Id("customer.address.state")).Clear();
            _driver.FindElement(By.Id("customer.address.state")).SendKeys(state);

            _driver.FindElement(By.Id("customer.address.zipCode")).Clear();
            _driver.FindElement(By.Id("customer.address.zipCode")).SendKeys(zipCode);

            _driver.FindElement(By.Id("customer.phoneNumber")).Clear();
            _driver.FindElement(By.Id("customer.phoneNumber")).SendKeys(phone);

            _driver.FindElement(By.CssSelector("input[value='Update Profile']")).Click();

            _wait.Until(d => d.FindElement(By.XPath("//*[contains(text(),'Your updated address and phone number have been added to the system.')]")));
        }
    }
}
