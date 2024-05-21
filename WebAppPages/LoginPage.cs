using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nopCommerce_AutomationFramework.WebAppPages
{
    public class LoginPage : CorePage
    {
        #region Locators
        By loginPageBtn = By.XPath("//a[@class='ico-login']");
        By emailTxt = By.Id("Email");
        By passwordTxt = By.Id("Password");
        By loginBtn = By.XPath("//button[normalize-space()='Log in']");
        #endregion
        public void OpenLoginPage(string url)
        {
            OpenUrl(url);
            Click(loginPageBtn);
        }
        public void Login(string email, string password)
        {
            Step = Test.CreateNode("Login Page");

            Write(emailTxt, email);
            Write(passwordTxt, password);
            Click(loginBtn);
        }
    }
}
