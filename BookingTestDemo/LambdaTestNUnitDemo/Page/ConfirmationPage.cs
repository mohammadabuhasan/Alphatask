using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBookingDemo.Page
{
    public class ConfirmationPage : BasePage
    {
        private By _confirmedBadge = By.CssSelector("span[class='conf-page-gem-offers__badge-text']");

        public ConfirmationPage(IWebDriver driver) : base(driver)
        {
        }

        public void verifyIfConfirmationBadgeIsDisplayed()
        {
            WaitForPageToLoad();
            IsElementVisible(_confirmedBadge);
        }

    }
}
