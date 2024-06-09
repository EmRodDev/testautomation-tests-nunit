using OpenQA.Selenium;
using System.Globalization;
using TestAutomation.Tests.PageObjectPattern.Models;
using TestAutomation.Tests.PageObjectPattern.PageObjects.HomePage;

namespace TestAutomation.Tests.PageObjectPattern.Helpers
{
    public static class FruitHelper
    {
        public static IList<FruitWebElement> Parse(IList<IWebElement> fruits) => fruits.Select(fruit => new FruitWebElement(fruit)).ToList();

        public static IList<FruitModel> Parse(IList<FruitWebElement> fruits) => fruits.Select(fruit => Parse(fruit)).ToList();

        //This method converts an IWebElement into a FruitModel
        public static FruitModel Parse(FruitWebElement element)
        {
            decimal value = decimal.Parse(element.Value.Split(' ')[0],new CultureInfo("en-US"));

            return new FruitModel(element.Name, value, element.Description);
        }
    }
}
