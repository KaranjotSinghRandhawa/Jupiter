using TestProject1.Pages;

namespace TestProject1.Tests
{
    [TestFixture]
    class TestCase1 : BaseTest
    {
        [Test]
        public void ValidateErrorsOnContactPage()
        {
            HomePage homePage = new HomePage();
            Assert.That(homePage.VerifyHomePageIsDisplayed(), Is.True);

            homePage.ClickOnContactTab();

            ContactPage contactPage = new ContactPage();
            Assert.That(contactPage.VerifyContactPageIsDisplayed(), Is.True);

            contactPage.ClickOnSubmitButton();

            contactPage.VerifyErrorMessagesAreDisplayed();

            contactPage.PopulateMandatoryFields();

            contactPage.VerifyErrorMessagesAreNotDisplayed();
        }
    }
}