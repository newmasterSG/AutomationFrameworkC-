using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OwnFramework.Reporting
{
    public class Report
    {
        private string BrowserType;
        private string url;
        private DateTime date; // Переменная нужна,чтобы создавать каждый раз разное имя файла по дате его создания
        private FileStream fs; //Переменная для файла,который создаётся,чтобы хранить себе репортинг по тесту
        private StringBuilder reportcsv; //Создаём билдер, чтобы добалять туда строки, для прохождения теста 
        private string filePath;
        public string fileName;
        public Report(string BrowserType, string url) // Передаём имя браузера, с класса Driver, и саму URL
        {
            this.BrowserType = BrowserType;
            this.url = url;
            date = DateTime.Now;
            fileName = date.Date.Date.ToShortDateString() + date.TimeOfDay.Hours.ToString() + date.TimeOfDay.Minutes.ToString();// Создание имени файла, берётся короткая дата(день,может и год и месяц), часы и минуты - создаётся без пробелов
            reportcsv = new StringBuilder();
            filePath = @"D:\NewVSCODE\OwnFramework\OwnFramework\Reports\" + fileName + ".csv";
            createCsvFile();
        }
        private void createCsvFile() // createCsvFile — эта функция создает документ нашего отчета и инициализирует его следующими заголовками: StepDescription — описание шага в тесте. Pass/Fail — результат тестового прогона. Exception — если было выбрано исключение.
        {
            reportcsv.Append("StepDescription,");
            reportcsv.Append("Pass/Fail,");
            reportcsv.Append("Exception");
            File.AppendAllText(filePath, reportcsv.ToString());
        }
        public void addLine(string description, string result, string exception) //addLine — функция, которая добавляет строку в наш отчет. Функция получает описание шага, результат и ожидаемый результат.
        {
            reportcsv.Append(Environment.NewLine);
            reportcsv.Append(description + ",");
            reportcsv.Append(result + ",");
            reportcsv.Append(exception + ",");
            reportcsv.Append(Environment.NewLine);
            File.WriteAllText(filePath, reportcsv.ToString());
        }

    }
}