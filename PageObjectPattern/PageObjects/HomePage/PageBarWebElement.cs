using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestAutomation.Tests.PageObjectPattern.PageObjects.HomePage
{
    public class PageBarWebElement
    {
        private readonly IWebDriver driver;
        public PageBarWebElement(IWebDriver driver)
        {
            this.driver = driver;
        }

        private IList<IWebElement> ButtonsPage => driver.FindElement(By.ClassName("pagination")).FindElements(By.XPath("//button[contains(@id,'page')]"));

        public HomePageObject ClickButtonPages(int number)
        {
            switch(number)
            {
                case 1:
                    ButtonsPage[0].Click();
                    break;
                case 2:
                    ButtonsPage[1].Click();
                    break;
                case 3:
                    ButtonsPage[2].Click();
                    break;
                default:
                    throw new Exception("Button not specified");
            }

            return new HomePageObject(driver);
        }
    }
}
