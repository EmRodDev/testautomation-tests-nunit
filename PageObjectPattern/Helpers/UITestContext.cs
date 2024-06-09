using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestAutomation.Tests.PageObjectPattern.Factories;

namespace TestAutomation.Tests.PageObjectPattern.Helpers
{
    public class UITestContext : IDisposable
    {
        public IWebDriver Driver { get; set;}

        public UITestContext()
        {

            Driver = WebDriverFactory.GetWebDriver(TestBase.TestSettings.Browser.ToLower(), TestBase.TestSettings.Headless);
            Driver.Manage().Window.Maximize();
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(TestBase.TestSettings.WaitTimeout);
            Driver.Url = "https://curso.testautomation.es/FruitVegetablesShopWeb/index.html";
        }

        public void Dispose() => Driver.Dispose();
    }
}
