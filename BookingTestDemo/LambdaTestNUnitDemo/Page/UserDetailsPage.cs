using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBookingDemo.Util;

namespace TestBookingDemo.Page

{

    public class UserDetailsPage : BasePage
    {

        private readonly By _fname = By.CssSelector("input[name='firstname']");
        private readonly By _lname = By.CssSelector("input[name='lastname']");
        private readonly By _email = By.CssSelector("input[name='email']");
        private readonly By _phone = By.CssSelector("input[name='phone']");

        public UserDetailsPage(IWebDriver driver) : base(driver)
        {
        }

        public void fillUserDetails()
        {
            WaitForPageToLoad();
            // WaitUntilElementVisible(By.XPath("//title[not(@*)]"));
            // Console.WriteLine("Fill User Current Tab Title: " + _driver.Title);
            SendKeys(_fname, "Fname");
            SendKeys(_lname, "lname");
            SendKeys(_email, "mohtest@gmail.com");
            SendKeys(_phone, "112341123121234");
        }

        public void clickNext()
        {
            Click(CommonPageLocators._nextButton);
        }


    }
}
