using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nopCommerce_AutomationFramework.WebAppPages
{
    public class SelectProduct : CorePage
    {
        #region Locators
        By product = By.XPath("//div[@class='product-item']//img[@title='Show details for Apple MacBook Pro 13-inch']");
        #endregion
        public void Select()
        {
            Step = Test.CreateNode("Select Product Page");

            ScrollDownByPercentage(30);
            System.Threading.Thread.Sleep(1000);
            Click(product);
        }
    }
}
