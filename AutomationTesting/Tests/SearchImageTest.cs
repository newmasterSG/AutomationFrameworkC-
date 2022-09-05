using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using AutomationTesting.Pages;
using OwnFramework.BasePageTest;
using OwnFramework.Reporting;
using OwnFramework.DataReader;

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

        //Тот же тест что и SearchImage просто считывает с файла который указан в пути,что надо написать и всё
        //Работа с тем что написано в файле происходит как с массивов(листом) выбираем элементы
        [Test]
        public void filldatafromCsv()
        {
            string filePath = @"C:\Users\quick\Desktop\runFile.csv";
            List<string> data = new List<string>();
            data = Servers.general.loadCsvFile(filePath);
            for (int i = 0; i < data.Count; i++)
            {
                var values = data[i].Split(';');
                BasePage.homePage.IsSearchLineVisiable();
                BasePage.homePage.IsSearchLineVisiable();
                BasePage.homePage.WriteToSearch(values[0]);
                BasePage.homePage.ClickSeachButton();
                Assert.IsTrue(BasePage.searchPage.ImageCotent.Displayed);
            }
        }
    }
}
