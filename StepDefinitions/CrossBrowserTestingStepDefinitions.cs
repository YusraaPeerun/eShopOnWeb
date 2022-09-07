using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using eShopOnWeb.Test.Drivers;
using eShopOnWeb.Test.PageObjectModels;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Safari;

namespace eShopOnWeb.Test.StepDefinitions
{
    [Binding]

    public class CrossBrowserTestingStepDefinitions
    {
        MainPage mainPg = new MainPage();
        IWebDriver driver;
        [Given(@"User is using browser (.*)")]
        public void launchBrowser(String browserName)
        {
            if (browserName.Equals("Google Chrome"))
            {
                this.driver = new ChromeDriver();
            }
            else if (browserName.Equals("FireFox")) {
                
                this.driver = new FirefoxDriver();
            }
            else if (browserName.Equals("Edge"))
            {
                this.driver = new EdgeDriver();
               
            }
            else if (browserName.Equals("Safari"))
            {
                //this.driver = new SafariDriver();
                //doesn't work on windows - Apple discontinued the Safari for Windows

            }
        }

        [Given(@"navigate to Main page")]
        public void GivenNavigateToLoginPage()
        {
            mainPg.NavigateToMainPg(driver);
        }

       
        [Then(@"check main page title")]
        public void ThenCheckMainPageTitle()
        {
            mainPg.CheckTitle(driver);
            driver.Quit();
        }


    }
}
