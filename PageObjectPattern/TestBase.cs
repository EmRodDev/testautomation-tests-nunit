using Microsoft.Extensions.Configuration;
using TestAutomation.Tests.PageObjectPattern.Models;

namespace TestAutomation.Tests.PageObjectPattern
{
    [Parallelizable(ParallelScope.All)]
    public class TestBase
    {
        public static TestSettings TestSettings { get; set; }

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            TestSettings = new TestSettings();

            IConfigurationRoot settings = new ConfigurationBuilder().AddJsonFile("appsettings.json", false, false).Build();

            IConfigurationSection automationSettings = settings.GetSection("AutomationSettings");

            automationSettings.Bind(TestSettings);

        }
    }
}
