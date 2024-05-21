using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;

namespace nopCommerce_AutomationFramework
{
    public class CorePage
    {
        #region Properties
        public static IWebDriver driver;
        public static AventStack.ExtentReports.ExtentReports extentReports;
        public static AventStack.ExtentReports.ExtentTest Test;
        public static AventStack.ExtentReports.ExtentTest Step;
        #endregion
        public static void SeleniumInit(string browser)
        {
            if (browser == "Chrome")
            {
                var chromeOptions = new ChromeOptions();
                chromeOptions.AddArguments("--start-maximized");
                chromeOptions.AddArguments("--incognito");
                //chromeOptions.AddArguments("--headless");

                IWebDriver chromeDriver = new ChromeDriver(chromeOptions);
                driver = chromeDriver;
            }
            else if (browser == "Firefox")
            {
                var firefoxOptions = new FirefoxOptions();
                firefoxOptions.AddArguments("--start-maximized");
                //firefoxOptions.AddArguments("--private");
                //firefoxOptions.AddArguments("--headless");

                FirefoxDriver firefoxDriver = new FirefoxDriver(firefoxOptions);
                driver = firefoxDriver;
            }
            else if (browser == "Edge")
            {
                var edgeOptions = new EdgeOptions();
                edgeOptions.AddArguments("--start-maximized");
                //edgeOptions.AddArguments("--inprivate");
                //edgeOptions.AddArguments("--headless");

                EdgeDriver edgeDriver = new EdgeDriver(edgeOptions);
                driver = edgeDriver;
            }
        }

        public static void ScrollDownByPercentage(double percentage)
        {
            long scrollHeight = (long)((IJavaScriptExecutor)driver).ExecuteScript("return document.documentElement.scrollHeight");

            long scrollAmount = (long)(scrollHeight * percentage / 100);

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript($"window.scrollBy(0, {scrollAmount})");
        }

        public static void OpenUrl(string url)
        {
            driver.Url = url;
        }

        public static void Write(By by, string data)
        {
            try
            {
                driver.FindElement(by).SendKeys(data);
                TakeScreenshot(Status.Pass, data + "Data Entered Successfully");
            }
            catch (Exception e)
            {
                TakeScreenshot(Status.Fail, e.Message);
            }

        }
        public void Click(By by)
        {
            try
            {
                driver.FindElement(by).Click();
                TakeScreenshot(Status.Pass, "Clicked Successfully");
            }
            catch (Exception e)
            {
                TakeScreenshot(Status.Fail, e.Message);
            }
        }

        public static string GetText(By by)
        {
            return driver.FindElement(by).Text;
        }

        public static void CloseBrowser()
        {
            driver.Close();
            driver.Dispose();
            driver.Quit();
        }

        public static void CreateReport(string path)
        {
            extentReports = new AventStack.ExtentReports.ExtentReports();

            var htmlReporter = new ExtentHtmlReporter(path);
            extentReports.AttachReporter(htmlReporter);
        }

        public static void TakeScreenshot(Status status, string stepDetails)
        {
            string path = @"ExtentReports\TestExecImages\" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png";
            string i_path = @"TestExecImages\" + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".png";
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            File.WriteAllBytes(path, screenshot.AsByteArray);
            if (Step != null)
            {
                Step.Log(status, stepDetails).AddScreenCaptureFromPath(i_path);
            }
            else
            {
                Console.WriteLine("ExtentTest Step is not initialized. Skipping logging.");
            }
        }
    }
}
