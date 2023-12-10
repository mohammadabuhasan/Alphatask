using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestBookingDemo.Page
{
    public class StayDetailsPage : BasePage
    {
        private readonly By _reserveButton = By.CssSelector("form button[id='hp_book_now_button']");
        private readonly By _reserveButtonConfimation = By.CssSelector("button[data-tooltip-class='submit_holder_button_tooltip']");
        private readonly By _rtReserveButtonPrice = By.CssSelector("span[class='b-button__from-text book_now_rt_summary']");

        public StayDetailsPage(IWebDriver driver) : base(driver)
        {
        }

        public void clickReserve()
        {
            SwitchToNewTab();
            WaitForPageToLoad();
            Click(_reserveButton);
        }
        public void clickConfirmReserve()
        {   if(IsElementPresent(_reserveButtonConfimation))
                Click(_reserveButtonConfimation);
        }

    }
}
