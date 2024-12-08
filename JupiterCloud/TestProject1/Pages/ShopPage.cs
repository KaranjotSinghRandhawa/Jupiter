using OpenQA.Selenium;
using TestProject1.Libraries;

namespace TestProject1.Pages
{
    class ShopPage : CommonLibrary
    {
        private readonly By shopTab = By.Id("nav-shop");
        private readonly By toyName = By.CssSelector(".product");
        private readonly By buyButton = By.CssSelector(".btn-success");
        private readonly By cartButton = By.Id("nav-cart");
        private readonly By toyPrice = By.CssSelector(".product-price");
        private readonly string stuffedFrog = "Stuffed Frog";
        private readonly string fluffyBunny = "Fluffy Bunny";
        private readonly string valentineBear = "Valentine Bear";
        private readonly int numberOfStuffedFrogToBuy = 2;
        private readonly int numberOfFluffyBunnyToBuy = 5;
        private readonly int numberOfValentineBearToBuy = 3;

        public bool VerifyShopPageIsDisplayed()
        {
            return VerifyElementIsDisplayed(shopTab);
        }

        public void SelectAnItem(string itemName)
        {
            SelectElement(Driver.FindElements(toyName), Driver.FindElements(buyButton), itemName);
        }

        public void ClickOnCart()
        {
            ClickElement(cartButton);
        }

        public double ToyPriceValue(string itemName)
        {
            string toyPriceValueWithDollarSign = GetPrice(Driver.FindElements(toyName), Driver.FindElements(toyPrice), itemName);
            string toyPriceValueWithoutDollarSign = toyPriceValueWithDollarSign.Substring(toyPriceValueWithDollarSign.IndexOf("$") + 1);
            return double.Parse(toyPriceValueWithoutDollarSign);
        }

        public double PriceOfStuffedFrogFromShopPage()
        {
            return ToyPriceValue(stuffedFrog);
        }

        public double PriceOfFluffyBunnyFromShopPage()
        {
            return ToyPriceValue(fluffyBunny);
        }

        public double PriceOfValentineBearFromShopPage()
        {
            return ToyPriceValue(valentineBear);
        }

        public double SubtotalOfStuffedFrogFromShopPage()
        {
            return ToyPriceValue(stuffedFrog) * numberOfStuffedFrogToBuy;
        }

        public double SubtotalOfFluffyBunnyFromShopPage()
        {
            return ToyPriceValue(fluffyBunny) * numberOfFluffyBunnyToBuy;
        }

        public double SubtotalOfValentineBearFromShopPage()
        {
            return ToyPriceValue(valentineBear) * numberOfValentineBearToBuy;
        }

        public void SelectMultipleToys(int numberOfToys, string itemName)
        {
            for (int i=1; i <= numberOfToys; i++)
            {
                SelectAnItem(itemName);
            }
        }

        public void BuyToys()
        {
            SelectMultipleToys(numberOfStuffedFrogToBuy, stuffedFrog);
            SelectMultipleToys(numberOfFluffyBunnyToBuy, fluffyBunny);
            SelectMultipleToys(numberOfValentineBearToBuy, valentineBear);
        }
    }
}