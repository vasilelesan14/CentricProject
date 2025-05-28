using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace CentricUnitTestProject.PageObjectModel
{
    class OpenAccountPage
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public OpenAccountPage(IWebDriver driver)
        {
            _driver = driver;
            _wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
        }

        public void GoToOpenAccountPage()
        {
            _driver.FindElement(By.LinkText("Open New Account")).Click();
            _wait.Until(d => d.FindElement(By.XPath("//h1[text()='Open New Account']")));
        }

        public void OpenNewAccount(string accountType = "SAVINGS", string sourceAccountId = null)
        {
            var typeDropdown = _wait.Until(d => d.FindElement(By.Id("type")));
            var typeOptions = typeDropdown.FindElements(By.TagName("option"));
            foreach (var option in typeOptions)
            {
                if (option.Text.Trim().Equals(accountType, StringComparison.OrdinalIgnoreCase))
                {
                    option.Click();
                    break;
                }
            }

            // asteapta ca dropdown-ul sa aiba optiuni valide
            var fromDropdown = _wait.Until(d =>
            {
                var dropdown = d.FindElement(By.Id("fromAccountId"));
                var opts = dropdown.FindElements(By.TagName("option"));
                return opts.Count > 0 ? dropdown : null;
            });

            var fromOptions = fromDropdown.FindElements(By.TagName("option"));
            bool accountFound = false;

            if (!string.IsNullOrEmpty(sourceAccountId))
            {
                foreach (var option in fromOptions)
                {
                    if (option.GetAttribute("value") == sourceAccountId)
                    {
                        option.Click();
                        accountFound = true;
                        break;
                    }
                }

                if (!accountFound)
                {
                    throw new Exception($"source account {sourceAccountId} not found. Available: {string.Join(", ", fromOptions.Select(o => o.GetAttribute("value")))}");
                }
            }
            else
            {
                var firstValid = fromOptions.FirstOrDefault(o => !string.IsNullOrWhiteSpace(o.GetAttribute("value")));
                if (firstValid != null)
                {
                    firstValid.Click();
                }
                else
                {
                    throw new Exception("no valid account found in dropdown");
                }
            }

            _driver.FindElement(By.XPath("//input[@value='Open New Account']")).Click();
            Thread.Sleep(500);
            _wait.Until(d => d.FindElement(By.XPath("//h1[text()='Account Opened!']")));
        }

        public string GetNewAccountId()
        {
            var accountLink = _wait.Until(d => d.FindElement(By.Id("newAccountId")));
            return accountLink.Text;
        }
    }
}
