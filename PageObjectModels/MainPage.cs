using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShopOnWeb.Test.Drivers;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace eShopOnWeb.Test.PageObjectModels
{
    public class MainPage 
    {
        public string MainpgUrl = "https://localhost:44315/";

        public MainPage NavigateToMainPg(IWebDriver driver)
        {
            driver.Navigate().GoToUrl(MainpgUrl);
            return this;
        }

        public void CheckTitle(IWebDriver driver)
        {
            Assert.AreEqual("Catalog - Microsoft.eShopOnWeb", driver.Title);
        }

        public MainPage clickOnLogInBtn(IWebDriver driver)
        {
            driver.FindElement(By.CssSelector("body > div > header > div > article > section.col-lg-4.col-md-5.col-xs-12 > div > section > div > a")).Click();
            return this;
     
        }

        public MainPage changeBrand(IWebDriver driver,String brand)
        {
            IWebElement selectBrand = driver.FindElement(By.Id("CatalogModel_BrandFilterApplied"));
            SelectElement brandOption = new SelectElement(selectBrand);
            brandOption.SelectByText(brand);
            driver.FindElement(By.ClassName("esh-catalog-send")).Click();
            return this;

        }

        public MainPage AddProductInTheBasket(ReadOnlyCollection<IWebElement> itemsOnScreen, String itemToAddInBasket)
        {
            for (int countItem = 1; countItem <= itemsOnScreen.Count; countItem++)
            {
                String currentText = (itemsOnScreen[countItem]).FindElement(By.XPath("form/div[1]/span")).Text;
                if (currentText.Equals(itemToAddInBasket))
                {
                    Assert.AreEqual(currentText, itemToAddInBasket);
                    itemsOnScreen[countItem].FindElement(By.XPath("form/input[1]")).Click();
                    break;

                }
            }
            return this;

        }

        public MainPage addMultipleProductsInTheBasket(ReadOnlyCollection<IWebElement> itemsOnScreen, IWebDriver driver, int numberOfProducts)
        {
            for (int i = 1; i <= numberOfProducts; i++)
            {
                itemsOnScreen[i].FindElement(By.XPath("form/input[1]")).Click();
                updateQuantity(driver,"1");
                updateBtn(driver);
                if (i < numberOfProducts)
                {
                    driver.FindElement(By.XPath("/html/body/div/div/form/div/div[3]/section[1]/a")).Click();
                }
            }
            return this;
        }

        public MainPage updateQuantity(IWebDriver driver, string quantity)
        {
            driver.FindElement(By.ClassName("esh-basket-input")).Clear();
            driver.FindElement(By.ClassName("esh-basket-input")).SendKeys(quantity);
            return this;
        }

        public MainPage updateBtn(IWebDriver driver)
        {
            driver.FindElement(By.Name("updatebutton")).Click();
            return this;
        }

        public MainPage checkoutBtn(IWebDriver driver)
        {
            driver.FindElement(By.XPath("/html/body/div/div/form/div/div[3]/section[2]/a")).Click();
            return this;
        }
    }
}
