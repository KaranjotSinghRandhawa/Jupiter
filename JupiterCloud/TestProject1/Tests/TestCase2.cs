using TestProject1.Pages;

namespace TestProject1.Tests
{
    [TestFixture]
    class TestCase2 : BaseTest
    {
        [Test]
        public void ValidateSuccessfulSubmissionOnContactPage()
        {
            HomePage homePage = new HomePage();
            Assert.That(homePage.VerifyHomePageIsDisplayed(), Is.True);

            homePage.ClickOnContactTab();

            ContactPage contactPage = new ContactPage();
            Assert.That(contactPage.VerifyContactPageIsDisplayed(), Is.True);

            contactPage.PopulateMandatoryFields();

            contactPage.ClickOnSubmitButton();

            contactPage.SuccessfulSubmissionMessageIsDisplayed();
        }
    }
}