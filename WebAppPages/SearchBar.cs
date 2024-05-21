using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nopCommerce_AutomationFramework.WebAppPages
{
    public class SearchBar : CorePage
    {
        #region Locators
        By searchBar = By.Id("small-searchterms");
        By searchBtn = By.XPath("//button[@type='submit']");
        #endregion
        public void Search(string searchTxt)
        {
            Step = Test.CreateNode("Search Bar");

            Write(searchBar, searchTxt);
            Click(searchBtn);
        }
    }
}
