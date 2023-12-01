using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace YourNamespace
{
    public class CourseraHomePage
    {
        private readonly IWebDriver driver;

        public CourseraHomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void Open()
        {
            driver.Navigate().GoToUrl("https://www.coursera.org/");
        }

        public bool IsTitleCorrect()
        {
            return driver.Title.StartsWith("Coursera | Build Skills with Online Courses from Top Institutions");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var testClass = new TestClass1();
            testClass.Setup();

            try
            {
                // Run the tests
                testClass.OpenCourseraWebsite();
            }
            finally
            {
                // Cleanup
                testClass.Cleanup();
            }
        }
    }

    [TestFixture]
    public class TestClass1
    {
        private IWebDriver? driver;
        public CourseraHomePage? courseraHomePage;

        [SetUp]
        public void Setup()
        {
            new DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver(@"D:\chromedriver-win64\chromedriver.exe");
            courseraHomePage = new CourseraHomePage(driver);
        }

        [Test]
        public void OpenCourseraWebsite()
        {
            courseraHomePage.Open();
            Assert.IsFalse(courseraHomePage.IsTitleCorrect());
        }

        [TearDown]
        public void Cleanup()
        {
            driver?.Quit();
        }
    }
}