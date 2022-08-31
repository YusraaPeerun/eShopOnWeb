using System;
using eShopOnWeb.Test.Drivers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace eShopOnWeb.Test.StepDefinitions
{

    [Binding]
    public class InvalidLoginStepDefinitions : logInTestingStepDefinitions
    {


        String password => driver.FindElement(By.Id("Input_Password")).GetAttribute("value");
        String fieldEmail => driver.FindElement(By.Id("Input_Email")).GetAttribute("value");

        [Then(@"Error message (.*) appears")]
        public void ThenErrorMessageInvalidLoginAttempt_Appears(String ErrorMsg)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           ReadOnlyCollection <IWebElement> currentErrorMsg = driver.FindElements(By.XPath("//div[@class='text-danger validation-summary-errors']/ul/li"));
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

        [Then(@"Another error message appears below the field Password: (.*)")]
        public void ThenAnotherErrorMessageAppears_BelowTheFieldPassword(String ErrorMsg)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var currentErrorMsg = wait.Until(driver =>
                driver.FindElement(By.XPath("/html/body/div/div/div/div/section/form/div[3]/span/span")));
            Assert.AreEqual(ErrorMsg, currentErrorMsg.Text);
        }

        [Then(@"Another error message appears below the field Email: (.*)")]
        public void ThenAnotherErrorMessageAppearsBelowTheFieldEmail(String ErrorMsg)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var currentErrorMsg = wait.Until(driver =>
                driver.FindElement(By.XPath("/html/body/div/div/div/div/section/form/div[2]/span/span")));
            Assert.AreEqual(ErrorMsg, currentErrorMsg.Text);
        }


        [Then(@"Field Email is not blanked out")]
        public void ThenFieldEmailIsNotBlankedOut()
        {
            Assert.IsNotEmpty(fieldEmail);
        }

        [Then(@"Field Password is blanked out")]
        public void ThenFiledPasswordIsBlankedOut()
        {
            Assert.IsEmpty(password);
            driver.Quit();

        }

        [Then(@"Field Email is blanked out")]
        public void ThenFieldEmailIsBlankedOut()
        {
            Assert.IsEmpty(fieldEmail);
        }

        [Then(@"Field Password is not blanked out")]
        public void ThenFiledPasswordIsNotBlankedOut()
        {            
            Assert.IsNotEmpty(password);
            driver.Quit();
        }

    }
}
