using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace CentricUnitTestProject.PageObjectModel
{
    public class RequestLoanPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public RequestLoanPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void GoToRequestLoanPage()
        {
            _driver.FindElement(By.LinkText("Request Loan")).Click();
            _wait.Until(d => d.FindElement(By.XPath("//*[@id=\"requestLoanForm\"]/h1")));
        }

        public void RequestLoan(decimal amount, decimal downPayment, string fromAccountId)
        {
            _driver.FindElement(By.Id("amount")).Clear();
            _driver.FindElement(By.Id("amount")).SendKeys(amount.ToString());

            _driver.FindElement(By.Id("downPayment")).Clear();
            _driver.FindElement(By.Id("downPayment")).SendKeys(downPayment.ToString());

            var fromAccountDropdown = _driver.FindElement(By.Id("fromAccountId"));
            var options = fromAccountDropdown.FindElements(By.TagName("option"));
            bool found = false;
            foreach (var option in options)
            {
                if (option.GetAttribute("value") == fromAccountId)
                {
                    option.Click();
                    found = true;
                    break;
                }
            }

            if (!found)
                throw new Exception($"account {fromAccountId} not found in dropdown");

            Thread.Sleep(1000);

            _driver.FindElement(By.XPath("//input[@value='Apply Now']")).Click();

            _wait.Until(d => d.FindElement(By.XPath("//*[contains(text(),'Loan Request Processed')]")));
        }

        public bool IsLoanApproved()
        {
            var statusElement = _wait.Until(d => d.FindElement(By.Id("loanStatus")));

            Thread.Sleep(1000);

            return statusElement.Text.Trim().Equals("Approved", StringComparison.OrdinalIgnoreCase);
        }

    }
}
