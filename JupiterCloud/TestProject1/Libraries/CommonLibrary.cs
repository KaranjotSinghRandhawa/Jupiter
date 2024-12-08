using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestProject1.Libraries
{
    public class CommonLibrary
    {
        protected static IWebDriver Driver;
        private string _jupiterURL = "http://jupiter.cloud.planittesting.com/";

        public void InitialiseDriver()
        {
            Driver = new FirefoxDriver();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public void MaximiseWindow()
        {
            Driver.Manage().Window.Maximize();
        }

        public void NavigateToJupiterWebsite()
        {
            Driver.Navigate().GoToUrl(_jupiterURL);
        }

        public void QuitDriver()
        {
            if (Driver != null)
            {
                Driver.Quit();
            }
        }

        public static void WaitUntilElementIsVisible(IWebDriver driver, By locator, int timeoutInSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
            try
            {
                IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(locator));

            }
            catch (WebDriverTimeoutException)
            {
                Console.WriteLine("Element not found within the given time.");
            }
        }

        public bool VerifyElementIsDisplayed(By ele)
        {
            return Driver.FindElement(ele).Displayed;
        }

        public string getElementText(By ele)
        {
            return Driver.FindElement(ele).Text;
        }

        public bool IsElementTextCorrect(By ele, string eleText)
        {
            return getElementText(ele) == eleText;
        }

        public void ElementShouldNotBeDisplayed(By ele)
        {
            try
            {
                // Try to find the element
                var element = Driver.FindElement(ele);

                // Check if the element is displayed
                if (element.Displayed)
                {
                    Assert.Fail("Element is displayed but should not be.");
                }
            }
            catch (NoSuchElementException)
            {
                // Element is not present in the DOM, which is the expected outcome
            }
        }
        
        public void ClickElement(By ele)
        {
            Driver.FindElement(ele).Click();
        }

        public void WaitForElementToBeClickable(By element, long timeSpan = 10)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(10)); // Wait for 10 seconds
            wait.Until(driver => driver.FindElement(element).Displayed && driver.FindElement(element).Enabled);
        }

        public string GetfElementText(By ele)
        {
            return Driver.FindElement(ele).Text;
        }

        public void FillTextField(By ele, string enterText)
        {
            Driver.FindElement(ele).SendKeys(enterText);
        }

        public void SelectElement(IList<IWebElement> toyNameElements, IList<IWebElement> buyElements, string toyName)
        {
            int i = 0;
            do
            {
                IWebElement buyElement = buyElements[i];
                IWebElement toyNameElement = toyNameElements[i];
                if (toyNameElement.Text.Contains(toyName))
                {
                    buyElement.Click();
                    break;
                }
                else
                {
                    i++;
                }
            }
            while (i < toyNameElements.Count);
        }

        public string GetPrice(IList<IWebElement> toyNameElements, IList<IWebElement> toyPriceElements, string toyName)
        {
            int i = 0;
            IWebElement toyPriceElement;
            do
            {
                toyPriceElement = toyPriceElements[i];
                IWebElement toyNameElement = toyNameElements[i];
                Console.WriteLine(toyNameElement.Text);
                if (toyNameElement.Text.Contains(toyName))
                {
                    break;
                }
                else
                {
                    i++;
                }
            }
            while (i < toyNameElements.Count);
            return toyPriceElement.Text;
        }
    }
}