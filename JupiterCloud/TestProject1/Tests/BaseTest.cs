using TestProject1.Libraries;

namespace TestProject1.Tests
{
    public class BaseTest
    {
        CommonLibrary commonLibrary = new CommonLibrary();

        [SetUp]
        public void Setup()
        {
            commonLibrary.InitialiseDriver();
            commonLibrary.MaximiseWindow();
            commonLibrary.NavigateToJupiterWebsite();
        }

        [TearDown]
        public void TearDown()
        {
            commonLibrary.QuitDriver();
        }
    }
}