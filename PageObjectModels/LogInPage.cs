using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V102.Page;
using OpenQA.Selenium.Support.UI;

namespace eShopOnWeb.Test.Drivers
{
    public class LogInPage
    {
        public string loginUrl = "https://localhost:44315/Identity/Account/Login";

        public LogInPage NavigateToLogInPg(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(loginUrl);
            return this;
        }

        public LogInPage enterEmail(IWebDriver driver, string email)
        {
            driver.FindElement(By.Id("Input_Email")).SendKeys(email);
            return this;
        }

        public LogInPage enterPassword(IWebDriver driver, string password)
        {
            driver.FindElement(By.Id("Input_Password")).SendKeys(password);
            return this;
        }

        public LogInPage clickOnLogInBtn(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector(".btn-default")).Click();
            return this;
        }

        public void checkErrorMsg(IWebDriver driver, String ErrorMsg)
        {

            ReadOnlyCollection<IWebElement> currentErrorMsg = driver.FindElements(By.XPath("//div[@class='text-danger validation-summary-errors']/ul/li"));
            int num = currentErrorMsg.Count();
            if (currentErrorMsg.Count.Equals(1) || ErrorMsg.Contains("Email"))
            {
                Assert.AreEqual(ErrorMsg, currentErrorMsg[0].Text);
            }
            else if (ErrorMsg.Contains("Password"))
            {
                Assert.AreEqual(ErrorMsg, currentErrorMsg[1].Text);
            }
        }

        public void checkMsgBelowFieldEmail(IWebDriver driver, String ErrorMsg)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var currentErrorMsg = wait.Until(driver =>
                driver.FindElement(By.XPath("/html/body/div/div/div/div/section/form/div[2]/span/span")));
            Assert.AreEqual(ErrorMsg, currentErrorMsg.Text);
        }

        public void checkMsgBelowFieldPasswordl(IWebDriver driver, String ErrorMsg)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var currentErrorMsg = wait.Until(driver =>
                driver.FindElement(By.XPath("/html/body/div/div/div/div/section/form/div[3]/span/span")));
            Assert.AreEqual(ErrorMsg, currentErrorMsg.Text);
        }
    }
}
