using OfficeOpenXml;
using System;

namespace ExcelFileConfigurator.Classes
{
    internal class ExcelGenerator
    {
        private static readonly string[] sheetNames = new string[] { "Список машин", "Список панелей", "Список объектов", "График монтажа" };

        public byte[] GenerateHeader(int Floors, string currentDate, string destinatonDate)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            var package = new ExcelPackage();

            string[] date = currentDate.Split('.');
            DateTime CurrentDate = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));

            date = new string[2];
            date = destinatonDate.Split('.');
            DateTime DestinationDate = new DateTime(int.Parse(date[2]), int.Parse(date[1]), int.Parse(date[0]));

            int Span = (DestinationDate.Date - CurrentDate.Date).Days;

            #region CarListCreate
            var sheet = package.Workbook.Worksheets.Add(sheetNames[0]);
            sheet.Cells[1, 1].Value = "Марка машины";
            sheet.Cells[1, 2].Value = "Номер машины";
            sheet.Cells[1, 3].Value = "К-во мест для панелей";
            sheet.Cells[1, 4].Value = "Доступность";

            int rowCount = sheet.Dimension.End.Row; //Get row count
            int colCount = sheet.Dimension.End.Column; //Get row count
            sheet.Cells[1, 1, rowCount, colCount].AutoFitColumns(); //Autosize
            #endregion
            #region PanelListCreate
            sheet = package.Workbook.Worksheets.Add(sheetNames[1]);
            sheet.Cells[1, 1].Value = "Номер панели";
            sheet.Cells[1, 2].Value = "Название панели";
            sheet.Cells[1, 3].Value = "К-во доступных панелей";

            rowCount = sheet.Dimension.End.Row; //Get row count
            colCount = sheet.Dimension.End.Column; //Get row count
            sheet.Cells[1, 1, rowCount, colCount].AutoFitColumns(); //Autosize
            #endregion
            #region ObjectsListCreate
            sheet = package.Workbook.Worksheets.Add(sheetNames[2]);
            sheet.Cells[1, 1].Value = "Название объекта";
            for (int i = 1; i <= Floors; i++)
            {
                sheet.Cells[1, i + 1].Value = i + " этаж";
            }

            rowCount = sheet.Dimension.End.Row; //Get row count
            colCount = sheet.Dimension.End.Column; //Get row count
            sheet.Cells[1, 1, rowCount, colCount].AutoFitColumns(); //Autosize
            #endregion
            #region ShedulePlanCreate
            sheet = package.Workbook.Worksheets.Add(sheetNames[3]);
            sheet.Cells[1, 1].Value = "Название объекта";
            DateTime added;
            for (int i = 0; i <= Span; i++)
            {
                added = CurrentDate.AddDays(i);
                sheet.Cells[1, i + 2].Value = added.ToShortDateString();
            }

            rowCount = sheet.Dimension.End.Row; //Get row count
            colCount = sheet.Dimension.End.Column; //Get row count
            sheet.Cells[1, 1, rowCount, colCount].AutoFitColumns(); //Autosize
            #endregion

            return package.GetAsByteArray();
        }
    }
}
