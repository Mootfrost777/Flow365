using OfficeOpenXml;
using System;

namespace ExcelFileConfigurator.Classes
{
    public class Panel
    {
        public string name { get; set; }
        public string destination { get; set; }
        public DateTime date { get; set; }

        public Panel(string name, string destination, DateTime date)
        {
            this.name = name;
            this.destination = destination;
            this.date = date;
        }
    }
}