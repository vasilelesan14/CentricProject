using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace CentricUnitTestProject.PageObjectModel
{
    public class ContactPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public ContactPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void GoToContactPage()
        {
            _driver.FindElement(By.LinkText("Contact Us")).Click();
            _wait.Until(d => d.FindElement(By.XPath("//h1[text()='Customer Care']")));
        }

        public void SendMessage(string name, string email, string phone, string message)
        {
            _wait.Until(d => d.FindElement(By.Name("name"))).SendKeys(name);
            _driver.FindElement(By.Name("email")).SendKeys(email);
            _driver.FindElement(By.Name("phone"))?.SendKeys(phone);
            _driver.FindElement(By.Name("message")).SendKeys(message);

            _driver.FindElement(By.XPath("//input[@value='Send to Customer Care']")).Click();
            Thread.Sleep(500);
            // asteapta confirmarea
            _wait.Until(d => d.FindElement(By.XPath("//*[@id=\'rightPanel\']/p[2]")));
            Thread.Sleep(500);
        }

        public bool IsMessageSent()
        {
            try
            {
                var thanks = _wait.Until(d => d.FindElement(By.XPath("//*[@id=\'rightPanel\']/p[2]")));
                return thanks.Displayed;
            }
            catch
            {
                return false;
            }
        }
    }
}
