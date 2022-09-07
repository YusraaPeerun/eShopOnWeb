using System;
using eShopOnWeb.Test.Drivers;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using eShopOnWeb.Test.PageObjectModels;
using Microsoft.VisualBasic.FileIO;
using OpenQA.Selenium.Support.UI;
using System.Runtime.Intrinsics.X86;
using System.Collections.ObjectModel;
using NUnit.Framework;
using System.Numerics;
using OpenQA.Selenium.Interactions;

namespace eShopOnWeb.Test.StepDefinitions
{
    [Binding]
    public class OrderAProductStepDefinitions
    {
        private MainPage mainPg = new MainPage();
        private logInTestingStepDefinitions logInSuccessfully = new logInTestingStepDefinitions();
        IWebDriver driver => logInSuccessfully.driver;
        ReadOnlyCollection<IWebElement> itemsOnScreen => driver.FindElements(By.XPath("/html/body/div/div/div[2]/div"));
        ReadOnlyCollection<IWebElement> currentItemOnOrderDetails => driver.FindElements(By.XPath("/html/body/div/div/div/section[3]/article"));

        [Given(@"User logged in with email add (.*) and password (.*)")]
        public void LoggedInSuccessfully(String email, String pass)
        {            
            logInSuccessfully.GivenUserIsOnLogInPage();
            logInSuccessfully.GivenUserEntersEmailAddress(email);
            logInSuccessfully.GivenUserEntersPassword(pass);
            logInSuccessfully.WhenClickOnTheLogInButton();
        }

        [Given(@"User click on the LOGIN button")]
        public void ClickOnTheLOGINButton()
        {
            mainPg.clickOnLogInBtn(driver);
        }

        [Given(@"select BRAND = (.*)")]
        public void SelectBRAND(String brand)            
        {
            mainPg.changeBrand(driver,brand);
        }

        [When(@"User add product (.*) in the basket")]
        public void Add1ProductInTheBasket(String itemName)
        {
            mainPg.AddProductInTheBasket(itemsOnScreen,itemName);
        }

        [Given(@"Add (.*) products in the basket for BRAND = (.*)")]
        public void addMultipleProductsInTheBasket(int numberOfProducts,String brand)
        {
            // mainPg.addMultipleProductsInTheBasket(itemsOnScreen, driver, numberOfProducts);
            for (int i = 1; i <= numberOfProducts; i++)
            {
                itemsOnScreen[i].FindElement(By.XPath("form/input[1]")).Click();

                ChangeTheQuantityTo("1");
                ClickOnTheButtonUPDATE();
                //Thread.Sleep(3000);
                if (i < numberOfProducts)
                {
                    driver.FindElement(By.XPath("/html/body/div/div/form/div/div[3]/section[1]/a")).Click();
                    SelectBRAND(brand);
                }
            }

        }


        [Then(@"directed to the basket")]
        public void CheckBasketPage()
        {
            Assert.AreEqual("https://localhost:44315/Basket", driver.Url);
            
        }

        [Given(@"User change the quantity to (.*)")]
        public void ChangeTheQuantityTo(String quantity)
        {
            mainPg.updateQuantity(driver,quantity);
            
        }

        [Then(@"an alert is displayed - (.*)")]
        public void CheckAlertIsDisplayed(String alertText)   //NEED TO IMPLEMENT
        {
            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            //IAlert alert = wait.Until(driver => driver.SwitchTo().Alert());
            //String actualAlertText = alert.Text;
            //Console.WriteLine("Actual alrt is :" + actualAlertText);
            //Assert.AreEqual(alertText, actualAlertText);
        }


        [Given(@"User click on the button UPDATE")]
        public void ClickOnTheButtonUPDATE()
        {
            mainPg.updateBtn(driver);
         
        }

        [When(@"User click on the button CHECKOUT")]
        public void ClickOnTheButtonCHECKOUT()
        {
            mainPg.checkoutBtn(driver);            
            
        }

        [Then(@"directed to the review page")]
        public void CheckReviewPage()
        {
            Assert.AreEqual("Checkout - Microsoft.eShopOnWeb", logInSuccessfully.driver.Title);           
        }

        [Then(@"item is (.*) on the review page and quantity is (.*)")]
        public void checkItemOnTheReviewPage(String item, String quantity)
        {
            ReadOnlyCollection<IWebElement> currentItem = driver.FindElements(By.XPath("/html/body/div/div/form/div/article/div[1]/section"));
            Assert.AreEqual(item, currentItem[1].Text);
            Assert.AreEqual(quantity, currentItem[3].Text);
        }

        [When(@"User click on the button PAYNOW")]
        public void ClickOnTheButtonPAYNOW()
        {
            driver.FindElement(By.ClassName("esh-basket-checkout")).Submit();
        }

        [Then(@"directed to the page Thanks for your order")]
        public void CheckPageThanksForYourOrder()
        {
            Assert.AreEqual("Checkout Complete - Microsoft.eShopOnWeb", driver.Title);
            String Currentmsg = driver.FindElement(By.XPath("/html/body/div/div/h1")).Text;
            Assert.AreEqual("Thanks for your Order!", Currentmsg);            
        }

        [Given(@"user hover on the email address on the top and click on my orders")]
        public void ClickOnMyOrders()
        {
            IWebElement emailAddHover = driver.FindElement(By.ClassName("esh-identity-name"));
            Actions action = new Actions(driver);
            action.MoveToElement(emailAddHover);
            IWebElement myOder = driver.FindElement(By.XPath("/html/body/div/header/div/article/section[2]/div/form/section[2]/a[1]/div"));
            action.MoveToElement(myOder);
            action.Click().Build().Perform();
        }

        [When(@"click on the button Detail for the latest item")]
        public void ClickOnTheButtonDetailForTheLatestItem()
        {
            ReadOnlyCollection<IWebElement> listOfOrderHistory = driver.FindElements(By.XPath("/html/body/div/div/div/article"));
            IWebElement lastItem = listOfOrderHistory[listOfOrderHistory.Count - 1];
            lastItem.FindElement(By.ClassName("esh-orders-link")).Click();
        }

        [Then(@"item on order details is (.*) and quantity is (.*)")]
         public void ItemOnOrderDetails(String item, String quantity)
        {
            Assert.AreEqual("Order Detail - Microsoft.eShopOnWeb", driver.Title);
            for (int i = 1; i < currentItemOnOrderDetails.Count; i++)
            {
                Assert.AreEqual(item, currentItemOnOrderDetails[i].FindElement(By.XPath("section[2]")).Text);   //html/body/div/div/div/section[3]/article[2]/section[2]
                Assert.AreEqual(quantity, currentItemOnOrderDetails[i].FindElement(By.XPath("section[4]")).Text);
            }
            driver.Quit();
        }

        [Then(@"check number of prodcuts is (.*)")]
        public void ThenCheckNumberOfProdcutsIs(int numOfProducts)
        {
            Assert.AreEqual(numOfProducts, currentItemOnOrderDetails.Count-1);
            driver.Quit();
        }


    }
}
