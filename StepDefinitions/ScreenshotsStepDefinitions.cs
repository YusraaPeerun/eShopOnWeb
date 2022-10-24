using System;
using ApprovalTests;
using ApprovalTests.Namers;
using ApprovalTests.Reporters;
using ApprovalTests.Reporters.Windows;
using DiffEngine;
using eShopOnWeb.Test.Drivers;
using eShopOnWeb.Test.PageObjectModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace eShopOnWeb.Test.StepDefinitions
{
    [Binding]
    public class ScreenshotsStepDefinitions
    {
        MainPage mainPg = new MainPage();
        LogInPage loginPg = new LogInPage();
        public IWebDriver driver = new ChromeDriver();

        [Given(@"user is on the (.*)")]
        public void GivenUserIsOn(String page)
        {
            if (("Main page").Equals(page)) {
                mainPg.NavigateToMainPg(driver);
            } else if (("Login page").Equals(page)) {
                loginPg.NavigateToLogInPg(driver);
            }else if (("Basket Page").Equals(page)) {
                driver.Navigate().GoToUrl("https://localhost:44315/Basket");
            }
}

        [When(@"Take a screenshot of the (.*)")]
        public void WhenTakeAScreenshotOfTheMainPage(String page)
        {
            ITakesScreenshot screenshotDriver = (ITakesScreenshot)driver;
            Screenshot screenshot = screenshotDriver.GetScreenshot();
            if (("Main page").Equals(page))
            {               
                screenshot.SaveAsFile("mainpage.bmp",ScreenshotImageFormat.Bmp);
            }
            else if (("Login page").Equals(page))
            {
                screenshot.SaveAsFile("loginpage.bmp", ScreenshotImageFormat.Bmp);
            }
            else if (("Basket Page").Equals(page))
            {
                screenshot.SaveAsFile("basketpage.bmp", ScreenshotImageFormat.Bmp);
            }
        }

        [Then(@"compare the screenshot page of the (.*)")]
        [UseReporter(typeof(BeyondCompareReporter))]
        public void ThenCompareTheScreenshotPage(String page)
        {
            FileInfo file = new FileInfo("mainpage.bmp");
            if (("Main page").Equals(page))
            {               
                file = new FileInfo("mainpage.bmp");
                using (ApprovalResults.ForScenario("mainpage")) {
                    Approvals.Verify(file);
                }                   
            }
            else if (("Login page").Equals(page))
            {
                file = new FileInfo("loginpage.bmp");
                using (ApprovalResults.ForScenario("loginpage"))
                {
                    Approvals.Verify(file);
                }
            }
            else if (("Basket Page").Equals(page))
            {
                file = new FileInfo("basketpage.bmp");
                using (ApprovalResults.ForScenario("basketpage"))
                {
                    Approvals.Verify(file);
                }
            }
            driver.Quit();
        }
    }
}
