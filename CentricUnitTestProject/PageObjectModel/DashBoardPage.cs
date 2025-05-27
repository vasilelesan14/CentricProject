using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;


namespace CentricUnitTestProject.PageObjectModel
{
    public class DashboardPage
    {
        private readonly IWebDriver driver;

        public DashboardPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public bool IsLoggedIn()
        {
            return driver.PageSource.Contains("Accounts Overview");
        }

        public void Logout()
        {
            driver.FindElement(By.LinkText("Log Out")).Click();
        }
    }
}
