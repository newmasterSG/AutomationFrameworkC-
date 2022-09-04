using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using OwnFramework.BasePageTest;
using OwnFramework.Driver;
using SeleniumExtras.PageObjects;

namespace AutomationTesting.Pages
{
    public class HomePage
    {

        #region elements
        public IWebElement SearchLine => Driver.GetWebDriver().FindElement(By.XPath("//input[contains(@title,'Поиск')]"));

        public IWebElement SearchButton => Driver.GetWebDriver().FindElement(By.XPath("//button[contains(@aria-label,'Поиск в Google')]"));

        #endregion

        #region methods
        public bool IsSearchLineVisiable()=>  SearchLine.Displayed;
        public bool IsSearchButtonVisiable()=> SearchButton.Displayed;
        public void ClickSeachButton() => SearchButton.Click();

        public void WriteToSearch(string word)
        {
            SearchLine.Clear();
            SearchLine.SendKeys(word);
        }
        #endregion
    }
}

