using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Diagnostics;


namespace TestAutomation.Tests.Start
{
    [TestFixture]
    public class BasicTests
    {
        IWebDriver driver;


        [SetUp]
        public void SetUp() 
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);

            //Go to URL
            driver.Url = "https://curso.testautomation.es/";
        }

        [Test]
        public void NormalLoadWebsiteTest()
        {

            //Defining the selector for the link
            IWebElement normalWebLink = driver.FindElement(By.Id("NormalWeb"));

            normalWebLink.Click();

            //Defining the selector for the title
            IWebElement title = driver.FindElement(By.CssSelector("h1"));

            //Text assertion
            title.Text.Should().Be("Normal load website");

        }

        [Test]
        public void SlowLoadWebsiteTest()
        {
            IWebElement slowWebLink = driver.FindElement(By.Id("SlowLoadWeb"));
            slowWebLink.Click();

            IWebElement title = driver.FindElement(By.Id("title"));

            title.Text.Should().Be("Slow load website");

        }

        [Test]
        public void SlowLoadTextWebsiteTest()
        {
            IWebElement slowWebLink = driver.FindElement(By.Id("SlowSpeedTextWeb"));
            slowWebLink.Click();

            IWebElement title = driver.FindElement(By.Id("title"));

            WaitForCondition(() => IsTextElement(title, "Slow load website"));


        }


        //Method to check if a text of an element matches a string
        private bool IsTextElement(IWebElement element, string expectedTest)
        {
            return element.Text == expectedTest;
        }

        //Custom method to check if the condition given is true for a given time
        private void WaitForCondition(Func<bool> condition, int msTimeout = 4000)
        {
            Stopwatch stopWatch = new Stopwatch();
            Exception? ex;

            do
            {
                try
                {
                    ex = null;
                    if (condition())
                    {
                        return;
                    }
                }
                catch (Exception e)
                {
                    ex = e;
                }
               
            } while (stopWatch.ElapsedMilliseconds < msTimeout);

            stopWatch.Stop();

            if (ex != null) 
            {
                throw new TimeoutException("Error executing the condition.", ex);
            }

            throw new TimeoutException("Error the condition was false");

        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }
    }

}
