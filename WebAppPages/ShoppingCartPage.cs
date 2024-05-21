using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nopCommerce_AutomationFramework.WebAppPages
{
    public class ShoppingCartPage : CorePage
    {
        #region Locators
        By shoppingCartBtn = By.XPath("//span[@class='cart-label']");
        By termsCheckbox = By.Id("termsofservice");
        By checkoutBtn = By.Id("checkout");
        #endregion
        public void CartCheck()
        {
            Step = Test.CreateNode("Shopping Cart Page");

            ScrollDownByPercentage(-10);
            System.Threading.Thread.Sleep(5000);
            Click(shoppingCartBtn);
            ScrollDownByPercentage(50);
            System.Threading.Thread.Sleep(1000);
            Click(termsCheckbox);
            Click(checkoutBtn);
            System.Threading.Thread.Sleep(3000);
        }
    }
}
