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
        String fieldPassword => driver.FindElement(By.Id("Input_Password")).GetAttribute("value");
        String fieldEmail => driver.FindElement(By.Id("Input_Email")).GetAttribute("value");

        private LogInPage logInpg = new LogInPage();

        [Then(@"Error message (.*) appears")]
        public void ThenErrorMessageInvalidLoginAttempt_Appears(String ErrorMsg)
        {
            logInpg.checkErrorMsg(driver, ErrorMsg);
        }

        [Then(@"Another error message appears below the field Password: (.*)")]
        public void ThenAnotherErrorMessageAppears_BelowTheFieldPassword(String ErrorMsg)
        {
           logInpg.checkMsgBelowFieldPasswordl(driver, ErrorMsg);
        }

        [Then(@"Another error message appears below the field Email: (.*)")]
        public void ThenAnotherErrorMessageAppearsBelowTheFieldEmail(String ErrorMsg)
        {
            logInpg.checkMsgBelowFieldEmail(driver, ErrorMsg);
        }


        [Then(@"Field Email is not blanked out")]
        public void ThenFieldEmailIsNotBlankedOut()
        {
            Assert.IsNotEmpty(fieldEmail);
        }

        [Then(@"Field Password is blanked out")]
        public void ThenFiledPasswordIsBlankedOut()
        {
            Assert.IsEmpty(fieldPassword);
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
            Assert.IsNotEmpty(fieldPassword);
            driver.Quit();
        }

    }
}
