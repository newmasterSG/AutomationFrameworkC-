using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using AutomationTesting.Pages;
using OwnFramework.BasePageTest;
using OwnFramework.Reporting;
namespace AutomationTesting.Tests
{
    public class SearchImageTest : BaseTest
    {
        private readonly string word = "cat";

        [Test]
        public void SearchImage()
        {
            BasePage.homePage.IsSearchLineVisiable();
            BasePage.homePage.IsSearchLineVisiable();
            BasePage.homePage.WriteToSearch(word);
            BasePage.homePage.ClickSeachButton();
            Assert.IsTrue(BasePage.searchPage.ImageCotent.Displayed);
        }

    }
}
