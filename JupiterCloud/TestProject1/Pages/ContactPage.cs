using OpenQA.Selenium;
using TestProject1.Libraries;

namespace TestProject1.Pages
{
    class ContactPage : CommonLibrary
    {
        private readonly By forenamePlaceholder = By.Id("forename");
        private readonly By emailPlaceholder = By.Id("email");
        private readonly By messagePlaceholder = By.Id("message");
        private readonly By submitButton = By.XPath("//a[text()='Submit']");
        private readonly By forenameErrorElement = By.Id("forename-err");
        private readonly By emailErrorElement = By.Id("email-err");
        private readonly By messageErrorElement = By.Id("message-err");

        private readonly string forenameErrorText = "Forename is required";
        private readonly string emailErrorText = "Email is required";
        private readonly string messageErrorText = "Message is required";
        private readonly string forenameTextFieldValue = "Mark";
        private readonly string emailTextFieldValue = "Mark.example@planit.net.au";
        private readonly string messageTextFieldValue = "Test Message";

        public bool VerifyContactPageIsDisplayed()
        {
            return VerifyElementIsDisplayed(forenamePlaceholder);
        }

        public void PopulateMandatoryFields()
        {
            FillTextField(forenamePlaceholder, forenameTextFieldValue);
            FillTextField(emailPlaceholder, emailTextFieldValue);
            FillTextField(messagePlaceholder, messageTextFieldValue);
        }

        public void ClickOnSubmitButton()
        {
            WaitForElementToBeClickable(submitButton);
            ClickElement(submitButton);
        }

        public void VerifyErrorMessagesAreDisplayed()
        {
            VerifyElementIsDisplayed(forenameErrorElement);
            bool forenameErrorResult = IsElementTextCorrect(forenameErrorElement, forenameErrorText);
            Assert.That(forenameErrorResult, Is.True);

            VerifyElementIsDisplayed(emailErrorElement);
            bool emailErrorResult = IsElementTextCorrect(emailErrorElement, emailErrorText);
            Assert.That(emailErrorResult, Is.True);

            VerifyElementIsDisplayed(messageErrorElement);
            bool messageErrorResult = IsElementTextCorrect(messageErrorElement, messageErrorText);
            Assert.That(messageErrorResult, Is.True);
        }

        public void VerifyErrorMessagesAreNotDisplayed()
        {
            ElementShouldNotBeDisplayed(forenameErrorElement);
            ElementShouldNotBeDisplayed(emailErrorElement);
            ElementShouldNotBeDisplayed(messageErrorElement);
        }

        public IWebElement FindDynamicSuccessMessage(string dynamicValue)
        {
            string xpath = $"//div[contains(@class, 'alert-success') and contains(., 'Thanks {dynamicValue}, we appreciate your feedback')]";
            return Driver.FindElement(By.XPath(xpath));
        }

        public void SuccessfulSubmissionMessageIsDisplayed()
        {
            WaitUntilElementIsVisible(Driver, forenamePlaceholder, 10);
            string actualSuccessfulSubmissionMessage = FindDynamicSuccessMessage(forenameTextFieldValue).Text;

            string expectedSuccessfulSubmissionMessage = $"Thanks {forenameTextFieldValue}, we appreciate your feedback.";

            Assert.That(actualSuccessfulSubmissionMessage, Is.EqualTo(expectedSuccessfulSubmissionMessage),
                $"The success message text does not match. Expected: '{expectedSuccessfulSubmissionMessage}', Actual: '{actualSuccessfulSubmissionMessage}'");
        }
    }
}