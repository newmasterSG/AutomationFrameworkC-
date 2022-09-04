using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OwnFramework.Reporting;

namespace OwnFramework.Driver
{
    // этот класс реализовает паттерн singleton - нужен чтобы всегда был только один обьект
    // можно тут про это прочитать https://metanit.com/sharp/patterns/2.3.php
    public class Driver // таким образом мы сможешь изменить браузера,можно использовать switch
    {
        private static IWebDriver driver;

        // Браузер и url надо будет настроить в файле app.config

        private static string browser = ConfigurationManager.AppSettings["browser"];
        private static string baseURL = ConfigurationManager.AppSettings["url"];

        public static ReportManager reports;
        private Driver() { } // не знаю для чего нужен

        public static IWebDriver GetWebDriver()
        {
            if (driver == null)
            {
                switch (browser)
                {
                    case "Chrome":
                        {
                            driver = new ChromeDriver();
                        }
                        break;

                    case "IE":
                        {
                            driver = new InternetExplorerDriver();
                        }
                        break;

                    case "Firefox":
                        {
                            driver = new FirefoxDriver();
                        }
                        break;

                    default:
                        driver = new ChromeDriver();
                        break;

                }
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(30));
                reports = new ReportManager(browser, baseURL);
            }
            return driver;
        }

        public static void Goto(string url)
        {
            driver.Url = url;
            reports.verifyURL(url); // Verifying the URL
        }

        public static void CloseBrowse()
        {
            driver.Quit();
            driver = null;
        }
    }
}
