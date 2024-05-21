using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nopCommerce_AutomationFramework.WebAppPages
{
    public class ProductPage : CorePage
    {
        #region Locators
        By addtocartBtn = By.XPath("//button[@id='add-to-cart-button-4']");
        #endregion
        public void AddtoCart()
        {
            Step = Test.CreateNode("Product Page");

            ScrollDownByPercentage(10);
            System.Threading.Thread.Sleep(1000);
            Click(addtocartBtn);
            System.Threading.Thread.Sleep(1000);
        }
    }
}
