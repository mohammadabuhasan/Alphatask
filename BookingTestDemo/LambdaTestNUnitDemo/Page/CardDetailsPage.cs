using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestBookingDemo.Util;

namespace TestBookingDemo.Page

{
    public class CardDetailsPage : BasePage
    {

        private readonly By _cctype = By.CssSelector("select[name='cc_type']");
        private readonly By _cctypeOption = By.CssSelector("select[name='cc_type'] option");
        private readonly By _cc_number = By.XPath("(//div[contains(@class, 'number')]//input[contains(@name, 'number')])[1]");
        private readonly By _cc_expDate = By.CssSelector("form input[name='expirationDate'][type='text']");
        private readonly By _cc_yearDDL = By.CssSelector("select[name='cc_year']");
        private readonly By _cc_yearOption = By.CssSelector("select[name='cc_year'] option");
        private readonly By _cc_cvc = By.CssSelector("input[name*='cvc']");
        private By _CreditCardFormWithPayPal = By.CssSelector("form[class*='CreditCardFormContainer']"); // this is credit card form when there is a paypal option in payment
        private By modalContinueBookingButton = By.CssSelector("div.bui-group__item button[data-bui-ref='modal-close']");
        private By noPaymentDiv = By.CssSelector("div[class*='no-payment']");
        private By payToProperty = By.CssSelector("div[data-testid*='PAY_TO_PROPERTY']");
        private By _paymentiFrame = By.CssSelector("iframe[title*='Payment']");
        private By _paymentDiv = By.CssSelector("div[data-capla-component-boundary*='PaymentInstrument']");

        private By _CardNumLabel = By.XPath("//label[contains(@for, 'pc-card-number-field-')]");

        private By _CardForm = By.CssSelector("form[class*='CreditCard']");

        private By _newCardTitle = By.CssSelector("span[class='current-selected-method-title new-card-title']");

        public CardDetailsPage(IWebDriver driver) : base(driver)
        {
        }

        public void clickNext()
        {
            Click(CommonPageLocators._nextButton);
        }
        public void fillCardDetails()
        {
            WaitForPageToLoad();
            
            if (!IsElementPresent(noPaymentDiv))
            {
                if(IsElementPresent(_paymentiFrame)) {

                    clickPayToProperty();
                    switchToIframe(_paymentiFrame);
                    Click(_cc_expDate);
                    MoveToElementAndSendKeys(_cc_expDate, "0330");
                }
                else
                {
                    MoveToElementAndClick(_cctype);
                    SelectElement select = new SelectElement(GetElement(_cctype));
                    select.SelectByText("MasterCard");
                    MoveToElementAndClick(_cc_yearDDL);
                    select = new SelectElement(GetElement(_cc_yearDDL));
                    select.SelectByText("2030");
                }
               
                MoveToElementAndSendKeys(_cc_number, "5555555555554444");
                if (IsElementPresent(_cc_cvc)){
                    MoveToElementAndSendKeys(_cc_cvc, "737");
                }

                switchToDefaultIframe();
            }

        }
        public void clickContinueBooking()
        {
            if (IsElementPresent(modalContinueBookingButton))
                Click(modalContinueBookingButton);
        }

        public void clickPayToProperty()
        {
            if (IsElementPresent(payToProperty))
                Click(payToProperty);
        }




    }

}
