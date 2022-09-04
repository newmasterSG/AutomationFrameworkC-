using System;
//using System.Collections.Generic;
using System.Text;
using OwnFramework.Driver;
using SeleniumExtras.PageObjects;
//using System.Collections;

namespace AutomationTesting.Pages
{
    public static class BasePage // После создания класса, обрабатывающего нашу страницу, мы реализуем его, создав еще один класс. Этот класс будет состоять из всего набора объектов страницы, который у нас есть. Это будет единственный класс, который может взаимодействовать с каждой страницей.
    {
        private static T getPages<T>() where T : new() // Создаёт инстансы(экземпляры) других страниц
        {
            var page = new T();
            PageFactory.InitElements(Driver.GetWebDriver(), page);
            return page;
        }

        // Обращение к странице(page) должно быть такое BasePage.YourPage.methods or BasePage.YourPage.property

        public static HomePage homePage => new HomePage();

        public static SearchPage searchPage => new SearchPage();


    }
}
