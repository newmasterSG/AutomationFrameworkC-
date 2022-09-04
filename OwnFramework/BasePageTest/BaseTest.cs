using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OwnFramework.Driver;

namespace OwnFramework.BasePageTest
{
    public class BaseTest
    {
        private IWebDriver driver;

        private readonly string image_url = "https://images.google.com/";
        [SetUp]
        public void Setup()
        {
            driver = Driver.Driver.GetWebDriver();
            Driver.Driver.Goto(image_url);
        }

        [TearDownAttribute]
        public void AfterDown() => Driver.Driver.CloseBrowse();
    }
}