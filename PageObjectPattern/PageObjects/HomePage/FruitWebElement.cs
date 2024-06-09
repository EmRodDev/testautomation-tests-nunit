using OpenQA.Selenium;

namespace TestAutomation.Tests.PageObjectPattern.PageObjects.HomePage
{
    public class FruitWebElement
    {
        private readonly IWebElement fruitWebElement;
        public string Name => fruitWebElement.FindElement(By.TagName("h2")).Text;
        public string Value => fruitWebElement.FindElement(By.TagName("p")).Text;
        public string Description => fruitWebElement.FindElements(By.TagName("p"))[1].Text;
        private IWebElement InputFieldQuantity => fruitWebElement.FindElement(By.CssSelector("[id$='Quantity']"));
        private IWebElement ButtonAddToCart => fruitWebElement.FindElement(By.TagName("button"));

        public FruitWebElement(IWebElement fruitWebElement)
        {
            this.fruitWebElement = fruitWebElement;
        }

        public void ClickAddToCart()
        {
            ButtonAddToCart.Click();
        }

        public FruitWebElement InputQuantity(int quantity)
        {
            InputFieldQuantity.Clear();

            InputFieldQuantity.SendKeys(quantity.ToString());

            return this;
        }
    }
}
