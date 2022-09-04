using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using OwnFramework.Driver;

namespace AutomationTesting.Pages
{
    public class SearchPage
    {
        #region elements
        public IWebElement ImageCotent => Driver.GetWebDriver().FindElement(By.XPath("//img[contains(@alt,'house cat')]"));
        #endregion
    }
}
