using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace TestAutomation.Tests.Selectors
{
    [TestFixture]
    public class SelectorTests
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
        public void TestSelector() 
        {
            driver.FindElement(By.Id("SelectorsWeb")).Click();

            //By ID
            driver.FindElement(By.Id("myId")).Text.Should().Be("Element 1");

            //By ClassName
            driver.FindElement(By.ClassName("className")).Text.Should().Be("Element 2");

            //Doing a list and choosing an element
            driver.FindElements(By.Id("myId"))[1].Text.Should().Be("Element 3");

            //By hierarchy
            IWebElement elementsDiv = driver.FindElement(By.Name("elements"));
            
            elementsDiv.FindElement(By.Id("myId")).Text.Should().Be("Element 3");

            //By CSS Selector
            driver.FindElement(By.CssSelector("[name='elements'] #myId")).Text.Should().Be("Element 3");

            //By name
            driver.FindElement(By.Name("myName")).Text.Should().Be("Element 4");

            //By Xpath
            driver.FindElement(By.XPath("//div[@style='color:magenta']/b")).Text.Should().Be("Element 5");

            //Making a list and verifying each remaining element
            ReadOnlyCollection<IWebElement> elementList = driver.FindElements(By.XPath("//div/div[contains(text(),'Element') and not(@class) and not(@id) and not(@name)]"));

            for(int i = 0; i < 3; i++)
            {
                elementList[i].Text.Should().Be("Element " + (i + 6));
            }
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }
}
