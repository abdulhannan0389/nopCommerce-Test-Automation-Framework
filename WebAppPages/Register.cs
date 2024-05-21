using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nopCommerce_AutomationFramework.WebAppPages
{
    public class Register : CorePage
    {
        #region Locators
        By registerPageBtn = By.XPath("//a[@class='ico-register']");
        By firstName = By.Id("FirstName");
        By lastName = By.Id("LastName");
        By emailTxt = By.Id("Email");
        By passwordTxt = By.Id("Password");
        By confirmPasswordTxt = By.Id("ConfirmPassword");
        By registerBtn = By.XPath("//button[@id='register-button']");
        #endregion
        public void OpenRegPage(string url)
        {
            OpenUrl(url);
            Click(registerPageBtn);
        }
        public void RegUser(string fName, string lName, string email, string password)
        {
            Step = Test.CreateNode("Register Page");

            Write(firstName, fName);
            Write(lastName, lName);
            Write(emailTxt, email);
            Write(passwordTxt, password);
            Write(confirmPasswordTxt, password);
            Click(registerBtn);
        }
    }
}
