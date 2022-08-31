using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V102.Page;

namespace eShopOnWeb.Test.Drivers
{
    public class LogInPage
    {
        public string loginUrl = "https://localhost:44315/Identity/Account/Login";      

        public LogInPage NavigateToLogInPg(IWebDriver driver) {
            driver.Navigate().GoToUrl(loginUrl);
            return this;
        }

        public LogInPage enterEmail(IWebDriver driver,string email)
        {
            driver.FindElement(By.Id("Input_Email")).SendKeys(email);
            return this;
        }

        public LogInPage enterPassword(IWebDriver driver,string password)
        {
            driver.FindElement(By.Id("Input_Password")).SendKeys(password);
            return this;
        }

        public LogInPage clickOnLogInBtn(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector(".btn-default")).Click();
            return this;
        }
    }
}
