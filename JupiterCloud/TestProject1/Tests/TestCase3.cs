using TestProject1.Pages;

namespace TestProject1.Tests
{
    [TestFixture]
    class TestCase3 : BaseTest
    {
        [Test]
        public void BuyToys()
        {
            HomePage homePage = new HomePage();
            Assert.True(homePage.VerifyHomePageIsDisplayed());

            homePage.ClickOnStartShoppingButton();
            
            ShopPage shopPage = new ShopPage();
            Assert.True(shopPage.VerifyShopPageIsDisplayed());

            //1.Buy 2 Stuffed Frog, 5 Fluffy Bunny, 3 Valentine Bear
            double priceOfStuffedFrogFromShopPage = shopPage.PriceOfStuffedFrogFromShopPage();
            double priceOfFluffyBunnyFromShopPage = shopPage.PriceOfFluffyBunnyFromShopPage();
            double priceOfValentineBearFromShopPage = shopPage.PriceOfValentineBearFromShopPage();
            double subtotalOfStuffedFrogFromShopPage = shopPage.SubtotalOfStuffedFrogFromShopPage();
            double subtotalOfFluffyBunnyFromShopPage = shopPage.SubtotalOfFluffyBunnyFromShopPage();
            double subtotalOfValentineBearFromShopPage = shopPage.SubtotalOfValentineBearFromShopPage();

            shopPage.BuyToys();

            //2.Go to the cart page
            homePage.ClickOnCartTab();

            CartPage cartPage = new CartPage();
            Assert.True(cartPage.VerifyCartPageIsDisplayed());

            //3.Verify the subtotal for each product is correct
            Assert.That(cartPage.SubtotalOfStuffedFrogFromCartPage(), Is.EqualTo(subtotalOfStuffedFrogFromShopPage));
            Assert.That(cartPage.SubtotalOfFluffyBunnyFromCartPage(), Is.EqualTo(subtotalOfFluffyBunnyFromShopPage));
            Assert.That(cartPage.SubtotalOfValentineBearFromCartPage(), Is.EqualTo(subtotalOfValentineBearFromShopPage));


            //4.Verify the price for each product
            Assert.That(cartPage.PriceOfStuffedFrogFromCartPage(), Is.EqualTo(priceOfStuffedFrogFromShopPage));
            Assert.That(cartPage.PriceOfFluffyBunnyFromCartPage(), Is.EqualTo(priceOfFluffyBunnyFromShopPage));
            Assert.That(cartPage.PriceOfValentineBearFromCartPage(), Is.EqualTo(priceOfValentineBearFromShopPage));

            //5.Verify that total = sum(sub totals)
            cartPage.TotalPrice();
            Assert.That(cartPage.TotalPrice(), Is.EqualTo(cartPage.SubtotalOfStuffedFrogFromCartPage() + cartPage.SubtotalOfFluffyBunnyFromCartPage() + cartPage.SubtotalOfValentineBearFromCartPage()));
        }
    }
}