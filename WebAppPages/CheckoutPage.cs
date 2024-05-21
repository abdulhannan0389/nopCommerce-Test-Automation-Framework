using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nopCommerce_AutomationFramework.WebAppPages
{
    public class CheckoutPage : CorePage
    {
        #region Locators
        By firstName = By.Id("BillingNewAddress_FirstName");
        By lastName = By.Id("BillingNewAddress_LastName");
        By email = By.Id("BillingNewAddress_Email");
        By country = By.Id("BillingNewAddress_CountryId");
        By city = By.Id("BillingNewAddress_City");
        By address1 = By.Id("BillingNewAddress_Address1");
        By zip = By.Id("BillingNewAddress_ZipPostalCode");
        By phone = By.Id("BillingNewAddress_PhoneNumber");
        By continueBtn = By.XPath("//button[@onclick='if (!window.__cfRLUnblockHandlers) return false; Billing.save()']");
        
        By shippingMethod = By.XPath("//label[@for='shippingoption_0']");
        By continueBtn2 = By.XPath("//button[@class='button-1 shipping-method-next-step-button']");

        By paymentMethod = By.XPath("//label[normalize-space()='Check / Money Order']");
        By continueBtn3 = By.XPath("//button[@class='button-1 payment-method-next-step-button']");

        //By paymentInfo = By.Id("CreditCardType");
        //By cardholderName = By.Id("CardholderName");
        //By cardNumber = By.Id("CardNumber");
        //By expireMonth = By.Id("ExpireMonth");
        //By expireYear = By.Id("ExpireYear");
        //By cardCode = By.Id("CardCode");
        By continueBtn4 = By.XPath("//button[@class='button-1 payment-info-next-step-button']");

        By confirmBtn = By.XPath("//button[normalize-space()='Confirm']");
        #endregion
        public void Checkout(/*string fName, string lName, string emailTxt, */string countryTxt, string cityTxt, string addressTxt, string zipTxt, string phoneTxt/*, string paymentInfoTxt, string cardholderNameTxt, string cardNumberTxt, string expireMonthTxt, string expireYearTxt, string cardCodeTxt*/)
        {
            //Step = Test.CreateNode("Checkout Info Page");

            //Write(firstName, fName);
            //Write(lastName, lName);
            //Write(email, emailTxt);
            Write(country, countryTxt);
            Write(city, cityTxt);
            Write(address1, addressTxt);
            Write(zip, zipTxt);
            Write(phone, phoneTxt);
            Click(continueBtn);
            System.Threading.Thread.Sleep(2000);

            Click(shippingMethod);
            Click(continueBtn2);
            System.Threading.Thread.Sleep(2000);
            
            Click(paymentMethod);
            Click(continueBtn3);
            System.Threading.Thread.Sleep(2000);

            //Write(paymentInfo, paymentInfoTxt);
            //Write(cardholderName, cardholderNameTxt);
            //Write(cardNumber, cardNumberTxt);
            //Write(expireMonth, expireMonthTxt);
            //Write(expireYear, expireYearTxt);
            //Write(cardCode, cardCodeTxt);
            Click(continueBtn4);
            System.Threading.Thread.Sleep(2000);

            ScrollDownByPercentage(40);
            System.Threading.Thread.Sleep(3000);
            Click(confirmBtn);
            System.Threading.Thread.Sleep(3000);
        }
    }
}
