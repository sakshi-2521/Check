using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Check
{
    [TestFixture]
    public abstract class Class1
    {
        protected ExtentReports _extent;
        protected ExtentTest _test;
        IWebDriver driver = new ChromeDriver();
        [OneTimeSetUp]
        protected void Setup()
        {
            var dir = TestContext.CurrentContext.TestDirectory + "\\";
            var fileName = this.GetType().ToString() + ".html";
            var htmlReporter = new ExtentHtmlReporter(@"C:\Users\nandi\source\repos\Check\Check\check.html");


            _extent = new ExtentReports();
            _extent.AttachReporter(htmlReporter);
        }
        [OneTimeTearDown]
        protected void TearDown()
        {
            _extent.Flush();
        }
        [TestFixture]
        public class TestInitializeWithNullValues : Class1
        {
            [Test]
            public void LaunchBrowser()
            {
                driver.Navigate().GoToUrl("https://in.pg.com/");
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
                driver.FindElement(By.XPath("//span[.='Our Impact']")).Click();
                driver.FindElement(By.XPath("//a[.='Sustainability']")).Click();
                IWebElement p = driver.FindElement(By.XPath("//span[.='P&G sustainability goals for 2030']"));
                string Text = p.Text;
                Console.WriteLine("..........." + Text + ".");
                driver.Quit();

            }

        }
        
    }
}
