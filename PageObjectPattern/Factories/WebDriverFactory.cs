using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;

namespace TestAutomation.Tests.PageObjectPattern.Factories
{
    public static class WebDriverFactory
    {
        public static IWebDriver GetWebDriver(string browserName, bool headless)
        {
            switch (browserName) 
            {
                case "edge" :

                    if (headless)
                    {
                        EdgeOptions edgeOptions = new EdgeOptions();
                        edgeOptions.AddArguments("--headless");
                        return new EdgeDriver(edgeOptions);
                    }
                    else
                    {
                        return new EdgeDriver();
                    }
                    
                case "chrome" :
                    if (headless)
                    {
                        ChromeOptions chromeOptions = new ChromeOptions();
                        chromeOptions.AddArguments("--headless");
                        return new ChromeDriver(chromeOptions);
                    }
                    else
                    {
                        return new ChromeDriver();
                    }

                case "firefox":
                    if (headless)
                    {
                        FirefoxOptions firefoxOptions = new FirefoxOptions();
                        firefoxOptions.AddArguments("--headless");
                        return new FirefoxDriver(firefoxOptions);
                    }
                    else
                    {
                        return new FirefoxDriver();
                    }

                default: throw new NotSupportedException($"The browser '{browserName}' does not exist or is not supported");
            }
        }
    }
}
