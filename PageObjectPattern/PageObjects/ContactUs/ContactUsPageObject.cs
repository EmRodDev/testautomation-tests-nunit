using FluentAssertions;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestAutomation.Tests.PageObjectPattern.PageObjects.ContactUs
{
    public class ContactUsPageObject
    {
        private IWebDriver driver;

        private IWebElement ContactTitleInputField => driver.FindElement(By.Id("contactTitle"));
        private IWebElement ContactEmailInputField => driver.FindElement(By.Id("contactEmail"));
        private SelectElement CategoryDropdown => new SelectElement(driver.FindElement(By.Id("contactCategory")));
        private IWebElement ContactMessageInputField => driver.FindElement(By.Id("contactText"));
        private IWebElement SubmitButton => driver.FindElement(By.CssSelector("#contactForm button"));
        private IWebElement Close => driver.FindElement(By.Id("closeContactPopup"));
        public IList<IWebElement> errorMessages => driver.FindElements(By.ClassName("error-message"));


        public ContactUsPageObject(IWebDriver driver)
        {
            this.driver = driver;
        }

        public ContactUsPageObject ClickSubmitButton() 
        {
            SubmitButton.Click();
            return this;
        } 

        public IEnumerable<string> GetCategoryOptions() => CategoryDropdown.Options.Select(category => category.Text);

        public ContactUsPageObject FillContactTitleInputField(string text) 
        {
            ContactTitleInputField.Clear();
            ContactTitleInputField.SendKeys(text);

            return this;
        } 
        public ContactUsPageObject FillContactEmailInputField(string text) 
        {
            ContactEmailInputField.Clear();
            ContactEmailInputField.SendKeys(text);

            return this;
        }
        public ContactUsPageObject FillContactMessageInputField(string text) 
        {
            ContactMessageInputField.Clear();
            ContactMessageInputField.SendKeys(text);

            return this;
        }

        public ContactUsPageObject SelectCategory (string category)
        {
            CategoryDropdown.SelectByText(category);

            return this;
        }



    }
}
