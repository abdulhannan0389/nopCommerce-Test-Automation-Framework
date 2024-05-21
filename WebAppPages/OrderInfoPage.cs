using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nopCommerce_AutomationFramework.WebAppPages
{
    public class OrderInfoPage : CorePage
    {
        #region Locators
        By orderDetails = By.XPath("//a[normalize-space()='Click here for order details.']");
        By pdfInvoice = By.XPath("//a[@class='button-2 pdf-invoice-button']");
        By logoutBtn = By.XPath("//a[@class='ico-logout']");
        #endregion
        public void GetOrderDetails()
        {
            Click(orderDetails);
            System.Threading.Thread.Sleep(1000);
            Step = Test.CreateNode("Order Info Page");
        }
        public void GetPdfInvoice()
        {
            Click(pdfInvoice);
            System.Threading.Thread.Sleep(5000);
        }
        public void Logout()
        {
            Click(logoutBtn);
            System.Threading.Thread.Sleep(1000);
        }
    }
}
