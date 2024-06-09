using OpenQA.Selenium;
using TestAutomation.Tests.PageObjectPattern.Helpers;
using TestAutomation.Tests.PageObjectPattern.Models;
using TestAutomation.Tests.PageObjectPattern.PageObjects.ContactUs;
using TestAutomation.Tests.PageObjectPattern.PageObjects.ShoppingCart;

namespace TestAutomation.Tests.PageObjectPattern.PageObjects.HomePage
{
    public class HomePageObject
    {
        private readonly IWebDriver driver;

        public HomePageObject(IWebDriver driver)
        {
            this.driver = driver;
        }


        private List<IWebElement> DisplayedFruits => driver.FindElements(By.ClassName("fruit")).Where(fruit => fruit.Displayed).ToList();

        private IWebElement ShoppingCartIcon => driver.FindElement(By.Id("cart-icon"));

        private IWebElement ContactUsButton => driver.FindElement(By.Id("openContactPopup"));

        public PageBarWebElement pageNavigation => new PageBarWebElement(driver);

        public SearchBarWebElement searchBar => new SearchBarWebElement(driver);

        public IList<FruitWebElement> DisplayedFruitWebElements() => FruitHelper.Parse(DisplayedFruits);

        public IList<FruitModel> DisplayedFruitsModels() => FruitHelper.Parse(DisplayedFruitWebElements());



        public bool IsGetShoppingCartIconNumberOfItems(int expectedNumber) 
        {
            try
            {
                WaitHelper.WaitForCondition(() => int.Parse(ShoppingCartIcon.Text).Equals(expectedNumber));
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public ShoppingCartPageObject ClickShoppingCartIcon ()
        {
            ShoppingCartIcon.Click();

            return new ShoppingCartPageObject(driver);
        }

        public ContactUsPageObject ClickContactUsButton()
        {
            ContactUsButton.Click();
            return new ContactUsPageObject(driver);
        }
    }
}
