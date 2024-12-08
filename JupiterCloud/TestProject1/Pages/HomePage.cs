using OpenQA.Selenium;
using TestProject1.Libraries;

namespace TestProject1.Pages
{
    class HomePage : CommonLibrary
    {
        private readonly By contactTab = By.Id("nav-contact");
        private readonly By cartTab = By.Id("nav-cart");
        private readonly By startShoppingLink = By.XPath("//a[text()='Start Shopping »']");
        private readonly By homePageHeading = By.XPath("//h1[text()='Jupiter Toys']");

        public bool VerifyHomePageIsDisplayed()
        {
            return VerifyElementIsDisplayed(homePageHeading);
        }

        public void ClickOnContactTab()
        {
            WaitForElementToBeClickable(contactTab);
            ClickElement(contactTab);
        }

        public void ClickOnStartShoppingButton()
        {
            WaitForElementToBeClickable(startShoppingLink);
            ClickElement(startShoppingLink);
        }

        public void ClickOnCartTab()
        {
            WaitForElementToBeClickable(cartTab);
            ClickElement(cartTab);
        }
    }
}