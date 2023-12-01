using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace YourNamespace
{
    public class CourseraInteractionPage
    {
        private readonly IWebDriver  driver;

        public CourseraInteractionPage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Open()
        {
            driver.Navigate().GoToUrl("https://www.coursera.org/");
        }

        public void PerformInteraction()
        {
            IWebElement categoryElement = driver.FindElement(By.CssSelector("a[data-click-key='front_page.front_page_story.click.header_right_nav_button']"));
            categoryElement.Click();

            // Add a wait here if needed
            System.Threading.Thread.Sleep(2000);

            Assert.IsTrue(driver.PageSource.Contains("З поверненням"));
        }
    }

    [TestFixture]
    public class TestClass2
    {
        public IWebDriver? driver;
        public CourseraInteractionPage? courseraInteractionPage;

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver(@"D:\chromedriver-win64\chromedriver.exe");
            courseraInteractionPage = new CourseraInteractionPage(driver);
        }

        [Test]
        public void PerformInteractionOnCoursera()
        {
            courseraInteractionPage.Open();
            courseraInteractionPage.PerformInteraction();
        }

        [TearDown]
        public void Cleanup()
        {
            driver?.Quit();
        }
    }
}