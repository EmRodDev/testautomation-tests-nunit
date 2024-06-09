using NUnit.Framework.Internal;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;

namespace TestAutomation.Tests.Frames
{
    [TestFixture]
    public class FrameTests
    {
        IWebDriver driver;

        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
            driver.Url = "https://curso.testautomation.es";
        }


        [Test]
        public void FrameTest()
        {
            driver.FindElement(By.Id("DifferentFrames")).Click();
            driver.FindElement(By.CssSelector("button")).Click();

            driver.SwitchTo().Frame(0);

            IWebElement webElementLeft = driver.FindElement(By.CssSelector("h2"));

            webElementLeft.Text.Equals("Welcome to the main frame!");

            driver.SwitchTo().DefaultContent();

            driver.SwitchTo().Frame(1);

            IWebElement webElementRight = driver.FindElement(By.CssSelector("h2"));

            webElementRight.Text.Equals("Content in the secondary frame!");


        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
