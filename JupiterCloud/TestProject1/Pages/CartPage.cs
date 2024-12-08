using OpenQA.Selenium;
using TestProject1.Libraries;

namespace TestProject1.Pages
{
    class CartPage : CommonLibrary
    {
        private readonly By cartTab = By.CssSelector("a.btn-checkout.btn.btn-success.ng-scope[href='#/checkout']");
        private readonly By totalValue = By.CssSelector(".total");
        private readonly By nameFromCart = By.XPath("//tr[contains(@class, 'cart-item')]/td[1]");
        private readonly By priceFromCart = By.XPath("//tr[contains(@class, 'cart-item')]/td[2]");
        private readonly By subtotalFromCart = By.XPath("//tr[contains(@class, 'cart-item')]/td[4]");

        public bool VerifyCartPageIsDisplayed()
        {
            return VerifyElementIsDisplayed(cartTab);
        }

        public double TotalPrice()
        {
            string totalStringValueWithTotalWord = GetfElementText(totalValue);
            string totalStringValue = totalStringValueWithTotalWord.Substring(totalStringValueWithTotalWord.IndexOf(":") + 2);
            return double.Parse(totalStringValue);
        }
        
        public double ToyPriceValue(string itemName)
        {
            string toyPriceValueWithDollarSign = GetPrice(Driver.FindElements(nameFromCart), Driver.FindElements(priceFromCart), itemName);
            string toyPriceValueWithoutDollarSign = toyPriceValueWithDollarSign.Substring(toyPriceValueWithDollarSign.IndexOf("$") + 1);
            return double.Parse(toyPriceValueWithoutDollarSign);
        }

        public double PriceOfStuffedFrogFromCartPage()
        {
            return ToyPriceValue("Stuffed Frog");
        }

        public double PriceOfFluffyBunnyFromCartPage()
        {
            return ToyPriceValue("Fluffy Bunny");
        }

        public double PriceOfValentineBearFromCartPage()
        {
            return ToyPriceValue("Valentine Bear");
        }

        public double SubtotalValue(string itemName)
        {
            string toyPriceValueWithDollarSign = GetPrice(Driver.FindElements(nameFromCart), Driver.FindElements(subtotalFromCart), itemName);
            string toyPriceValueWithoutDollarSign = toyPriceValueWithDollarSign.Substring(toyPriceValueWithDollarSign.IndexOf("$") + 1);
            return double.Parse(toyPriceValueWithoutDollarSign);
        }

        public double SubtotalOfStuffedFrogFromCartPage()
        {
            return SubtotalValue("Stuffed Frog");
        }

        public double SubtotalOfFluffyBunnyFromCartPage()
        {
            return SubtotalValue("Fluffy Bunny");
        }

        public double SubtotalOfValentineBearFromCartPage()
        {
            return SubtotalValue("Valentine Bear");
        }
    }
}