using System;
using System.Reflection;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using ExpectedConditions = SeleniumExtras.WaitHelpers.ExpectedConditions;
using TestBookingDemo.Util;

namespace TestBookingDemo.Page
{
    public class BasePage
    {
        protected readonly IWebDriver _driver;
        protected readonly WebDriverWait wait;
        protected readonly Actions actions;

        protected BasePage(IWebDriver driver)
        {
            _driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            actions = new Actions(_driver);
        }

        protected void WaitUntilElementVisible(By by)
        {
            //      var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(60));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }



        protected void WaitUntilElementClickable(By by)
        {
            try
            {
                wait.Until(ExpectedConditions.ElementToBeClickable(by));
            }
            catch (InvalidSelectorException ex)
            {
                Console.WriteLine($"Invalid selector used: {by.ToString()}");
                throw ex; // Re-throw the exception after printing the selector
            }
        }

        protected IWebElement GetElement(By by)
        {
            WaitUntilElementVisible(by);
            return _driver.FindElement(by);
        }

        protected void Click(By by)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by));
            _driver.FindElement(by).Click();
        }



        protected void SendKeys(By by, string text)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(by)); ;
            _driver.FindElement(by).SendKeys(text);
        }
        public bool IsElementVisible(By by)
        {
            try
            {
                IWebElement myElement = wait.Until(ExpectedConditions.ElementIsVisible(by));
                return myElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element is Not Present or Visible");
                return false;
            }


        }

        public bool IsElementPresentAndVisible(By by)
        {
            try
            {
                Console.WriteLine("Before Waiting for Element");
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(by));
                Console.WriteLine("Element is Present and Visible");
                return true;
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element is Not Present or Visible");
                return false;
            }
        }


        public (IWebElement element, int index) ClickRandomElementAndGetClickedElement(IList<IWebElement> elements)
        {
            // Check if there are elements to click
            if (elements.Count > 0)
            {
                // Generate a random index
                Random random = new Random();
                int randomIndex = random.Next(elements.Count);
                // Click the element at the random index
                MoveToElementAndClick(elements[randomIndex]);

                // Return a tuple containing the clicked element and its index
                return (elements[randomIndex], randomIndex);
            }
            else
            {
                Console.WriteLine("No elements found on the page.");
                return (null, -1); // Return -1 to indicate no elements were found
            }
        }
        public (IWebElement element, int index) ClickElementAtIndex(IList<IWebElement> elements, int index)
        {
            // Check if there are elements to click
            if (index >= 0 && index < elements.Count)
            {
                MoveToElementAndClick(elements[index]);
                return (elements[index], index);
            }
            else
            {
                Console.WriteLine("No elements found on the page.");
                return (null, -1);
            }
        }

        public void WaitForPageToLoad()
        {   // Use ExpectedConditions to wait for elements on the page to be ready
            wait.Until(d => ((IJavaScriptExecutor)d).ExecuteScript("return document.readyState").Equals("complete"));
        }


        public void ClickElementByText(IList<IWebElement> elements, string text)
        {
            // Find the element directly using LINQ
            IWebElement elementToClick = elements.FirstOrDefault(e => e.Text.Contains(text, StringComparison.OrdinalIgnoreCase));

            if (elementToClick != null)
            {
                // Click the element
                MoveToElementAndClick(elementToClick);

                // Optionally, you can add additional logic or validation after clicking
            }
            else
            {
                Console.WriteLine($"Element with text '{text}' not found in the list.");
                // Handle the case where the element is not found
            }
        }

        public void ScrollDown()
        {
            // Use Actions class to scroll to the middle of the page
            Actions actions = new Actions(_driver);
            actions.SendKeys(Keys.PageDown).Perform();
        }


        protected void MoveToElementAndSendKeys(By by, string text)
        {
            actions.MoveToElement(GetElement(by)).Click().SendKeys(text).Build().Perform();
        }
        protected void MoveToElementAndClick(By by)
        {
            //          actions.MoveByOffset(0, 200).Click().Build().Perform();
            actions.MoveToElement(GetElement(by)).Click().Build().Perform();

        }
        protected void MoveToElementAndClick(IWebElement element)
        {
            //          actions.MoveByOffset(0, 200).Click().Build().Perform();
            actions.MoveToElement(element).Click().Build().Perform();

        }
        public bool IsElementPresent(By by)
        {
            return _driver.FindElements(by).Count > 0;
        }

        public void SwitchToNewTab()
        {
            // Switch to the new tab
            var windowHandles = _driver.WindowHandles;
            string newTabHandle = windowHandles[windowHandles.Count - 1];
            _driver.SwitchTo().Window(newTabHandle);
        }

        public void WaitUntilElementIsHidden(By by)
        {
            try
            {
                // Wait until the element is hidden (not displayed)
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(by));
            }
            catch (WebDriverTimeoutException)
            {
                // Handle timeout exception if needed
                // You can throw an exception, log a message, or take other actions
            }

        }
            public void waitLoadingSpinnerToBeHidden()
        {
            WaitUntilElementIsHidden(CommonPageLocators._loadingSpinner);

        }
        public void switchToIframe(By by)
        {
            _driver.SwitchTo().Frame(GetElement(by));
          //  Console.WriteLine(IsElementPresent(by));
            //   wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.FrameToBeAvailableAndSwitchToIt(by));
            // 

        }
        public void switchToDefaultIframe()
        {
            _driver.SwitchTo().DefaultContent();
        }
        public bool IsElementClickable(By by)
        {
            try
            {
                IWebElement myElement = wait.Until(ExpectedConditions.ElementToBeClickable(by));
                return myElement.Displayed;
            }
            catch (NoSuchElementException)
            {
                Console.WriteLine("Element is Not Present or Visible");
                return false;
            }


        }

    }

    
}