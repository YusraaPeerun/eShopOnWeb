using System;
using eShopOnWeb.Test.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace eShopOnWeb.Test.StepDefinitions
{
    
    public class logInTestingStepDefinitions
    {
        public IWebDriver driver = new ChromeDriver();
        private LogInPage logInpg = new LogInPage();


        [Given(@"User is on log in page")]
        public void GivenUserIsOnLogInPage()
        {
            logInpg.NavigateToLogInPg(driver);           
            Assert.AreEqual("Log in - Microsoft.eShopOnWeb", driver.Title);
        }

        [Given(@"User enters email address (.*)")]
        public void GivenUserEntersEmailAddressDemouserMicrosoft_Com(String email)
        {
            logInpg.enterEmail(driver,email);
        }

        [Given(@"User enters Password (.*)")]
        public void GivenUserEntersPasswordPassWord(String password)
        {
            logInpg.enterPassword(driver, password);
        }

        [When(@"click on the Log in button")]
        public void WhenClickOnTheLogInButton()
        {
            logInpg.clickOnLogInBtn(driver);
        }

        [Then(@"directed to the main page")]
        public void ThenDirectedToTheMainPage()
        {
            Assert.AreEqual("Catalog - Microsoft.eShopOnWeb",driver.Title);
        }

        [Then(@"We should see the email address (.*) on top")]
        public void ThenWeShouldSeeTheEmaillAddressOnTop(String email)
        {
            string currentEmail = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/section[1]/div")).Text;
            Assert.AreEqual(currentEmail, email);
            driver.Quit();
        }
    }
}
