using OpenQA.Selenium;
using TestAutomation.Tests.PageObjectPattern.PageObjects.HomePage;

namespace TestAutomation.Tests.PageObjectPattern.PageObjects.ShoppingCart
{
    public class ShoppingCartPageObject
    {
        private readonly IWebDriver driver;

        private IWebElement ButtonClose => driver.FindElement(By.Id("CloseCart"));
        private IWebElement TotalPrice => driver.FindElement(By.Id("totalPrice"));

        private List<IWebElement> CartItems => driver.FindElements(By.ClassName("cart-item")).ToList();

        public IEnumerable<CartItemWebElement> CartItemsWebElements => CartItems.Select(item => new CartItemWebElement(item));

        public ShoppingCartPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public HomePageObject ClickButtonClose()
        {
            ButtonClose.Click();

            return new HomePageObject(driver);
        }

        public decimal GetTotalPrice() => decimal.Parse(TotalPrice.Text);

        public decimal GetTotalPriceFromItems() => CartItemsWebElements.Sum(item => item.GetTotalPrice());

    }
}
