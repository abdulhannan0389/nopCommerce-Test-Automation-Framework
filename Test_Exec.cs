using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using nopCommerce_AutomationFramework.WebAppPages;
using OpenQA.Selenium;
using System;
using System.Configuration;

namespace nopCommerce_AutomationFramework
{
    [TestClass]
    public class Test_Exec : CorePage
    {
        #region PageObjects
        private static Register register;
        private static LoginPage loginPage;
        private static SearchBar searchBar;
        private static SelectProduct selectProduct;
        private static ProductPage productPage;
        private static ShoppingCartPage shoppingCartPage;
        private static CheckoutPage checkoutPage;
        private static OrderInfoPage orderInfoPage;
        #endregion

        #region Initializations and Cleanups

        public TestContext instance;
        public TestContext TestContext
        {
            set { instance = value; }
            get { return instance; }
        }

        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {
            string ResultFile = @"ExtentReports\TestExecLog" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss")+".html";
            CreateReport(ResultFile);
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {
            extentReports.Flush();
        }

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            register = new Register();
            loginPage = new LoginPage();
            searchBar = new SearchBar();
            selectProduct = new SelectProduct();
            productPage = new ProductPage();
            shoppingCartPage = new ShoppingCartPage();
            checkoutPage = new CheckoutPage();
            orderInfoPage = new OrderInfoPage();
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            // Clean up resources used by the entire class
        }

        [TestInitialize]
        public void TestInit()
        {
            SeleniumInit(ConfigurationManager.AppSettings["DeviceBrowser"].ToString());
            Test = extentReports.CreateTest(TestContext.TestName);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            CloseBrowser();
        }

        #endregion

        [TestMethod]
        [TestCategory("Register")]
        public void TestCase_00()
        {
            register.OpenRegPage("https://demo.nopcommerce.com/");
            register.RegUser("Software", "Tester", "softwaretester@gmail.com", "softwaretester");

            string actualTxt = GetText(By.XPath("//div[@class='result']"));
            Assert.AreEqual("Your registration completed", actualTxt, "User Registered!");
        }
        
        [TestMethod]
        [TestCategory("Login")][TestCategory("Positive")]
        public void TestCase_01()
        {
            loginPage.OpenLoginPage("https://demo.nopcommerce.com/");
            loginPage.Login("softwaretester@gmail.com", "softwaretester");

            string actualTxt = GetText(By.XPath("//a[@class='ico-account']"));
            Assert.AreEqual("My account", actualTxt, "+ve Login Assertion Failed!");
        }

        [TestMethod]
        [TestCategory("Search")][TestCategory("Positive")]
        public void TestCase_02()
        {
            loginPage.OpenLoginPage("https://demo.nopcommerce.com/");
            loginPage.Login("softwaretester@gmail.com", "softwaretester");
            searchBar.Search("Apple MacBook Pro 13-inch");

            string actualTxt = GetText(By.XPath("//a[normalize-space()='Apple MacBook Pro 13-inch']"));
            Assert.AreEqual("Apple MacBook Pro 13-inch", actualTxt, "+ve Search Assertion Failed!");
        }

        [TestMethod]
        [TestCategory("Select")][TestCategory("Positive")]
        public void TestCase_03()
        {
            loginPage.OpenLoginPage("https://demo.nopcommerce.com/");
            loginPage.Login("softwaretester@gmail.com", "softwaretester");
            searchBar.Search("Apple MacBook Pro 13-inch");
            selectProduct.Select();

            string actualTxt = GetText(By.XPath("//h1[normalize-space()='Apple MacBook Pro 13-inch']"));
            Assert.AreEqual("Apple MacBook Pro 13-inch", actualTxt, "+ve Select Assertion Failed!");
        }

        [TestMethod]
        [TestCategory("AddToCart")][TestCategory("Positive")]
        public void TestCase_04()
        {
            loginPage.OpenLoginPage("https://demo.nopcommerce.com/");
            loginPage.Login("softwaretester@gmail.com", "softwaretester");
            searchBar.Search("Apple MacBook Pro 13-inch");
            selectProduct.Select();
            productPage.AddtoCart();

            string actualTxt = GetText(By.XPath("//div[@class='bar-notification success']"));
            Assert.AreEqual("The product has been added to your shopping cart", actualTxt, "+ve AddToCart Assertion Failed!");
        }

        [TestMethod]
        [TestCategory("CartReview&Checkout")][TestCategory("Positive")]
        public void TestCase_05()
        {
            loginPage.OpenLoginPage("https://demo.nopcommerce.com/");
            loginPage.Login("softwaretester@gmail.com", "softwaretester");
            searchBar.Search("Apple MacBook Pro 13-inch");
            selectProduct.Select();
            productPage.AddtoCart();
            shoppingCartPage.CartCheck();

            string actualTxt = GetText(By.XPath("//h1[normalize-space()='Checkout']"));
            Assert.AreEqual("Checkout", actualTxt, "+ve CartReview&Checkout Assertion Failed!");
        }

        [TestMethod]
        [TestCategory("Checkout")][TestCategory("Positive")]
        public void TestCase_06()
        {
            loginPage.OpenLoginPage("https://demo.nopcommerce.com/");
            loginPage.Login("softwaretester@gmail.com", "softwaretester");
            searchBar.Search("Apple MacBook Pro 13-inch");
            selectProduct.Select();
            productPage.AddtoCart();
            shoppingCartPage.CartCheck();
            checkoutPage.Checkout("Pakistan", "Karachi", "FAST NUCES City Campus", "75010", "03123456789");

            string actualTxt = GetText(By.XPath("//h1[normalize-space()='Thank you']"));
            Assert.AreEqual("Thank you", actualTxt, "+ve Checkout Assertion Failed!");
        }

        [TestMethod]
        [TestCategory("OrderInfo&Logout")]
        [TestCategory("Positive")]
        [TestCategory("E2E")]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "data.xml", "TestCase_07", DataAccessMethod.Sequential)]
        public void TestCase_07()
        {
            string url = TestContext.DataRow["url"].ToString();
            string email = TestContext.DataRow["email"].ToString();
            string password = TestContext.DataRow["password"].ToString();
            string product = TestContext.DataRow["product"].ToString();
            string country = TestContext.DataRow["country"].ToString();
            string city = TestContext.DataRow["city"].ToString();
            string address = TestContext.DataRow["address"].ToString();
            string zipcode = TestContext.DataRow["zipcode"].ToString();
            string phone = TestContext.DataRow["phone"].ToString();

            loginPage.OpenLoginPage(url);
            loginPage.Login(email, password);
            searchBar.Search(product);
            selectProduct.Select();
            productPage.AddtoCart();
            shoppingCartPage.CartCheck();
            checkoutPage.Checkout(country, city, address, zipcode, phone);
            orderInfoPage.GetOrderDetails();
            orderInfoPage.GetPdfInvoice();
            orderInfoPage.Logout();

            string actualTxt = GetText(By.XPath("//a[@class='ico-login']"));
            Assert.AreEqual("Log in", actualTxt, "+ve OrderInfo&Logout Assertion Failed!");
        }
    }
}
