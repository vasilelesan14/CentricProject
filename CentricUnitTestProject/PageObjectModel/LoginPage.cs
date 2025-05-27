using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CentricUnitTestProject.PageObjectModel
{
    public class LoginPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void GoToLoginPage()
        {
            _driver.Navigate().GoToUrl("https://parabank.parasoft.com/parabank/register.htm");
        }

        public void Login(string username, string password)
        {
            _wait.Until(d => d.FindElement(By.Name("username"))).SendKeys(username);
            _driver.FindElement(By.Name("password")).SendKeys(password);
            _driver.FindElement(By.XPath("//input[@value='Log In']")).Click();
        }

        public void LogOut()
        {
            _wait.Until(d => d.FindElement(By.XPath("//*[@id='leftPanel']/ul/li[8]/a"))).Click();
        }
    }
}
