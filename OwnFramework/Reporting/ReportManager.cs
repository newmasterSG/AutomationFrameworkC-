using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace OwnFramework.Reporting
{
    public class ReportManager
    {
        Report report;
        string browser;
        string url;
        IWebDriver driver = Driver.Driver.GetWebDriver();
        public ReportManager(string browser, string url)
        {
            this.browser = browser;
            this.url = url;
            report = new Report(browser, url);
        }
        public void verifyURL(string url) // функция, получающая URL-адрес веб-сайта и проверяющая, что мы находимся на реальной странице, найденной браузером. Чтобы получить текущий URL-адрес браузера, мы будем использовать driver.Url. Это причина создания переменной типа драйвера в начале. После этого мы сравним URL-адреса и напишем соответствующее сообщение для отчета.
        {
            string PageURL = driver.Url;
            string message = "The Current Url and Expected Url are not equals";
            if (PageURL.Equals(url))
                report.addLine("Verify url", "PASS", "Url are Equals");
            else
                report.addLine("Verify url", "FAIL", message);
            Assert.AreEqual(PageURL, url, message);
        }
        public void verifyElementNotAppear(IWebElement element) // функция, которая проверяет, не существует ли элемент на странице, и записывает результат в отчет.
        {
            if (!element.Displayed)
            {
                string message = "Element does not exist";
                Assert.Fail(message);
                addLog("Looking For Element" + element + "", "FAIL", element + " Should Be On The Page");
            }
        }
        public void addLog(string des, string res, string exp) // функция, которая записывает строку в наш отчет.
        {
            report.addLine(des, res, exp);
        }
    }
}
