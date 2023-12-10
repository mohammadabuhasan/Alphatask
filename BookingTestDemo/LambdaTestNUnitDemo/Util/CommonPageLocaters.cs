using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBookingDemo.Util
{

    public static class CommonPageLocators
    {
        public static readonly By _nextButton = By.CssSelector("button[name='book']");

        public static readonly By _loadingSpinner = By.CssSelector("div[data-testid='overlay-spinner']");

    }
}
