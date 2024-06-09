using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace TestAutomation.Tests.PageObjectPattern.PageObjects.HomePage
{
    [TestFixture]
    public class SearchBarWebElement
    {
        private readonly IWebDriver driver;

        public SearchBarWebElement(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IWebElement InputSearchProduct => driver.FindElement(By.Id("product-search"));

        private IWebElement ButtonSearch => driver.FindElement(By.Id("search-button"));

        public SearchBarWebElement InputSearch(string termToSearch)
        {
            this.ClearSearch();
            InputSearchProduct.SendKeys(termToSearch);

            return this;
        }

        public SearchBarWebElement ClearSearch()
        {
            InputSearchProduct.Clear();

            return this;
        }

        public HomePageObject ClickSearch()
        {
            ButtonSearch.Click();

            return new HomePageObject(driver);
        }

        public HomePageObject ClickEnter()
        {
            new Actions(driver).SendKeys(Keys.Enter).Perform();

            return new HomePageObject(driver);
        }
    }
}
