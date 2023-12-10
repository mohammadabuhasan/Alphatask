using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using TestBookingDemo.Base;

namespace TestBookingDemo.Test
{
    [TestFixture]
    public class BaseTest
    {
        protected IWebDriver Driver;
        private readonly string _baseUrl = Constants.BaseUrl;



        [SetUp]
        
        public void SetUp()
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(_baseUrl);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Quit();
        }
        }
    } 