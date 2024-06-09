using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TestAutomation.Tests.PageObjectPattern.Helpers;
using TestAutomation.Tests.PageObjectPattern.Models;
using TestAutomation.Tests.PageObjectPattern.PageObjects.ContactUs;
using TestAutomation.Tests.PageObjectPattern.PageObjects.HomePage;
using TestAutomation.Tests.PageObjectPattern.PageObjects.ShoppingCart;

namespace TestAutomation.Tests.PageObjectPattern
{
    public class FreshMarketTest : TestBase
    {


        [Test]
        public void FruitVerification()
        {
            //Setting up the context (to run the tests in parallel)
            using UITestContext uITestContext = new UITestContext();
            IWebDriver driver = uITestContext.Driver;

            //Verify that all these fruit models are present on the page
            List<FruitModel> expectedFruits = new List<FruitModel>
            {
                    new FruitModel("Apple", 2.50m, "Crispy and delicious apples from the orchard."),
                    new FruitModel("Banana", 1.00m, "Sweet and ripe bananas for a healthy snack."),
                    new FruitModel("Orange", 1.50m, "Fresh and juicy oranges for a Vitamin C boost."),
                    new FruitModel("Pear", 2.00m, "Sweet and juicy pears for a delightful taste."),
                    new FruitModel("Strawberry", 3.00m, "Red and juicy strawberries for a sweet treat."),
                    new FruitModel("Carrot", 1.20m, "Fresh and crunchy carrots for a healthy snack."),
                    new FruitModel("Grape", 2.80m, "Sweet and delicious grapes for a refreshing taste."),
                    new FruitModel("Watermelon", 0.80m, "Juicy and refreshing watermelon for hot days."),
                    new FruitModel("Cherry", 2.70m, "Sweet and vibrant cherries for a delightful taste."),
                    new FruitModel("Pumpkin", 1.80m, "Fresh and hearty pumpkin for a variety of recipes."),
                    new FruitModel("Broccoli", 1.80m, "Fresh and nutritious broccoli for a healthy diet."),
                    new FruitModel("Pineapple", 3.00m, "Sweet and tropical pineapples for a refreshing snack."),
                    new FruitModel("Cucumber", 0.80m, "Crisp and refreshing cucumbers for salads and snacks."),
                    new FruitModel("Potato", 1.20m, "Versatile and delicious potatoes for various dishes."),
                    new FruitModel("Lemon", 2.00m, "Zesty and tangy lemons for cooking and beverages."),
                    new FruitModel("Onion", 1.50m, "Flavorful and aromatic onions for cooking."),
                    new FruitModel("Peach", 2.20m, "Sweet and juicy peaches for a delightful summer treat."),
                    new FruitModel("Cabbage", 1.30m, "Crisp and crunchy cabbage for salads and coleslaw."),
                    new FruitModel("Grapefruit", 2.40m, "Tangy and refreshing grapefruits for a healthy start."),
                    new FruitModel("Kiwi", 3.20m, "Green and tangy kiwis for a tropical twist."),
                    new FruitModel("Tomato", 1.60m, "Plump and juicy tomatoes for salads and sauces."),
                    new FruitModel("Cantaloupe", 1.90m, "Sweet and aromatic cantaloupes for a refreshing treat."),
                    new FruitModel("Avocado", 2.80m, "Creamy and nutritious avocados for salads and guacamole."),
                    new FruitModel("Mango", 2.70m, "Exotic and sweet mangoes for a tropical delight."),
                    new FruitModel("Raspberry", 3.50m, "Delicate and flavorful raspberries for desserts and snacking."),
                    new FruitModel("Pomegranate", 4.00m, "Juicy and antioxidant-rich pomegranates for health-conscious individuals."),
                    new FruitModel("Blackberry", 2.80m, "Sweet and juicy blackberries for desserts and smoothies."),
                    new FruitModel("Cranberry", 3.20m, "Tart and antioxidant-packed cranberries for holiday dishes."),
            };

            List<FruitModel> result = new List<FruitModel>();

            HomePageObject homePage = new HomePageObject(driver);

            result.AddRange(homePage.DisplayedFruitsModels());

            result.AddRange(homePage.pageNavigation.ClickButtonPages(2).DisplayedFruitsModels());

            result.AddRange(homePage.pageNavigation.ClickButtonPages(3).DisplayedFruitsModels());

            result.Should().BeEquivalentTo(expectedFruits);
        }

        [Test]
        public void SearchTests()
        {
            //Setting up the context (to run the tests in parallel)
            using UITestContext uITestContext = new UITestContext();
            IWebDriver driver = uITestContext.Driver;

            HomePageObject homePage = new HomePageObject(driver);


            //Search "app" and verify that "Pineapple" and "Apple" items are present
            IList<FruitModel> foundFruitsFirst = homePage.searchBar.InputSearch("app").ClickSearch().DisplayedFruitsModels();

            foundFruitsFirst.Count().Should().Be(2);

            List<string> foundFruitsNamesFirst = foundFruitsFirst.Select(fruit => fruit.Name).ToList();

            string[] expectedFruitNamesFirst = new[] { "Pineapple", "Apple" };

            foundFruitsNamesFirst.Should().BeEquivalentTo(expectedFruitNamesFirst);

            //Clear the search bar, press "Search" button and verify that the 12 items are present

            IList<FruitModel> allFruits = homePage.searchBar.ClearSearch().ClickSearch().DisplayedFruitsModels();

            allFruits.Count().Should().Be(12);

            //Fill "ape" in the search bar, press key "Enter" and verify that "Grape" and "Grapefruit" items are present
            IList<FruitModel> foundFruitsSecond = homePage.searchBar.InputSearch("ape").ClickEnter().DisplayedFruitsModels();

            foundFruitsSecond.Count().Should().Be(2);

            List<string> foundFruitsNamesSecond = foundFruitsSecond.Select(fruit => fruit.Name).ToList();

            string[] expectedFruitNamesSecond = new[] { "Grape", "Grapefruit" };

            foundFruitsNamesSecond.Should().BeEquivalentTo(expectedFruitNamesSecond);


        }

        [Test]
        public void ShoppingCartTest()
        {
            //Setting up the context (to run the tests in parallel)
            using UITestContext uITestContext = new UITestContext();
            IWebDriver driver = uITestContext.Driver;

            HomePageObject homePage = new HomePageObject(driver);
            List<FruitModel> expectedFruitsInCart = new List<FruitModel>();


            //Verify that the shopping cart has zero items
            homePage.IsGetShoppingCartIconNumberOfItems(0).Should().BeTrue();

            //Add 10 apples, 6 bananas, 5 avocados and 1 pomegranate to the shopping cart using page navigation
            var element = homePage.DisplayedFruitWebElements();

            expectedFruitsInCart.Add(AddItemToCart(element, "Apple", 10));

            expectedFruitsInCart.Add(AddItemToCart(element, "Banana", 6));

            homePage.pageNavigation.ClickButtonPages(2);

            element = homePage.DisplayedFruitWebElements();
            expectedFruitsInCart.Add(AddItemToCart(element, "Avocado", 5));

            homePage.pageNavigation.ClickButtonPages(3);

            element = homePage.DisplayedFruitWebElements();
            expectedFruitsInCart.Add(AddItemToCart(element, "Pomegranate", 1));

            //Verify that the shopping cart has four items
            homePage.IsGetShoppingCartIconNumberOfItems(4).Should().BeTrue();

            /* Open the shopping cart and verify both added item values and the total */
            ShoppingCartPageObject cart = homePage.ClickShoppingCartIcon();

            IEnumerable<CartItemWebElement> items() => cart.CartItemsWebElements;

            items().Count().Should().Be(4);


            for(int i = 0; i < 4; i++)
            {
                FruitModel fruit = expectedFruitsInCart[i];
                items().ElementAt(i).GetText().Should().Be($"{fruit.Name} {fruit.Value} €/Kg");

                fruit.Quantity.Should().Be(items().ElementAt(i).GetQuantity());
            }

            //Compares the total of the fruits added into the total element
            cart.GetTotalPrice().Should().Be(cart.GetTotalPriceFromItems());

            //Removes the pomegranate and verifies that the shopping item number is 3
            items().ElementAt(3).ClickButtonRemove();
            homePage.IsGetShoppingCartIconNumberOfItems(3).Should().BeTrue();

            //Change the bananas quantity to 3 and verifies the total of the cart
            items().ElementAt(1).InputQuantity(3);
            cart.GetTotalPrice().Should().Be(cart.GetTotalPriceFromItems());

            //Close the cart
            cart.ClickButtonClose();

        }

        [Test]
        public void ContactUsTest()
        {
            //Setting up the context (to run the tests in parallel)
            using UITestContext uITestContext = new UITestContext();
            IWebDriver driver = uITestContext.Driver;

            HomePageObject homePage = new HomePageObject(driver);

            //Click 'Contact Us' button
            ContactUsPageObject contactUsForm = homePage.ClickContactUsButton();

            //Click 'Submit' button
            contactUsForm.ClickSubmitButton();

            //Validating the three error messages on the form
            contactUsForm.errorMessages.Count().Should().Be(3);

            //Verify the existence of the dropdown options
            contactUsForm.GetCategoryOptions().Should().BeEquivalentTo(new[] { "Search Information", "Career query", "Fruit enquiry", "Improvements", "Other" });

            //Fill all the fields with valid values and click submit
            contactUsForm
                .FillContactTitleInputField("Emanuel")
                .FillContactEmailInputField("emanuel@mail.com")
                .SelectCategory("Other")
                .FillContactMessageInputField("This is a message!")
                .ClickSubmitButton();

            //Verify the popup message
            IAlert alert = driver.SwitchTo().Alert();

            alert.Text.Should().Be("Form submitted successfully!");

            //Click the 'Accept' button
            alert.Accept();


        }

        public FruitModel AddItemToCart(IList<FruitWebElement> displayedFruits, string fruitName, int quantity)
        {
            FruitWebElement fruitWebElement = displayedFruits.Single(fruit => fruit.Name.Equals(fruitName));

            fruitWebElement.InputQuantity(quantity).ClickAddToCart();

            FruitModel fruitModel = FruitHelper.Parse(fruitWebElement);

            fruitModel.Quantity = quantity;

            return fruitModel;
        }

    }
}
