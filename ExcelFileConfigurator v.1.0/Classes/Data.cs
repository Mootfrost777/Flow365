using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;

namespace ExcelFileConfigurator.Classes
{
    internal class Data
    {
        private Queue<Panel> PanelsQueue = new Queue<Panel>();
        private DateTime date;

        private Tuple<string, string> GetAvalibleCar(string FilePath, int ExcelSheetNum)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; //License init

            FileInfo existingFile = new FileInfo(FilePath);
            using (ExcelPackage package = new ExcelPackage(existingFile))
            {
                //get the worksheet in the workbook
                ExcelWorksheet worksheet = package.Workbook.Worksheets[ExcelSheetNum]; //Change sheet
                int rowCount = worksheet.Dimension.End.Row; //Get row count

                for (int i = 2; i < rowCount; i++)
                {
                    if (worksheet.Cells[i, 4].Value?.ToString() == "да")
                    {
                        worksheet.Cells[i, 4].Value = "нет";
                        var reportExcel = package.GetAsByteArray();
                        File.WriteAllBytes(FilePath, reportExcel);
                        return Tuple.Create(worksheet.Cells[i, 2].Value?.ToString(),
                            worksheet.Cells[i, 3].Value?.ToString());
                    }
                }
            }

            return Tuple.Create("", "0");
        }

        private void ResetCars(string FilePath, int ExcelSheetNum)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; //License init

            FileInfo existingFile = new FileInfo(FilePath);
            using ExcelPackage package = new ExcelPackage(existingFile);
            //get the worksheet in the workbook
            ExcelWorksheet worksheet = package.Workbook.Worksheets[ExcelSheetNum]; //Change sheet
            int rowCount = worksheet.Dimension.End.Row; //Get row count

            for (int i = 2; i < rowCount; i++)
            {
                worksheet.Cells[i, 4].Value = "да";
            }

            var reportExcel = package.GetAsByteArray();
            File.WriteAllBytes(FilePath, reportExcel);
        }

        private Tuple<string, string[], DateTime> GetNeededResources(string FilePath, int ExcelSheetNum, int row,
            int col)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; //License init

            FileInfo existingFile = new FileInfo(FilePath);
            using ExcelPackage package = new ExcelPackage(existingFile); //get the worksheet in the workbook
            ExcelWorksheet worksheet = package.Workbook.Worksheets[ExcelSheetNum]; //Change sheet

            int rowCount = worksheet.Dimension.End.Row; //Get row count
            string[] arr = worksheet.Cells[row, col].Value?.ToString().Split(", ");
            string? destination = worksheet.Cells[row, 1].Value?.ToString();
            DateTime date = DateTime.Parse(worksheet.Cells[1, col].Value?.ToString());
            return Tuple.Create(destination, arr, date);
        }

        private void CreateSheet(string ExcelSavePath, string name)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; //License init
            var package = new ExcelPackage();
            var sheet = package.Workbook.Worksheets.Add(name); //Add new sheet
            sheet.Cells[1, 1].Value = "Дата";
            sheet.Cells[1, 2].Value = "Номер машины";
            sheet.Cells[1, 3].Value = "Назначение";
            sheet.Cells[1, 4].Value = "Панели";
            var reportExcel = package.GetAsByteArray();
            File.WriteAllBytes(ExcelSavePath, reportExcel);
        }
        

        private void Generate(string ExcelPath, string CarNum, int CarCapacity)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; //License init
            FileInfo existingFile = new FileInfo(ExcelPath);
            using ExcelPackage package = new ExcelPackage(existingFile);
            var sheet = package.Workbook.Worksheets[0];
            int rowCount = sheet.Dimension.End.Row; //Get row count
            for (int i = 0; i < CarCapacity; i++)
            {
                Panel panel = PanelsQueue.Dequeue();
                bool flag = false;
                for (int j = 1; j < rowCount; j++)
                {
                    if (sheet.Cells[j, 3].Value == panel.destination &&
                        sheet.Cells[j, 1].Value == panel.date.ToShortDateString() &&
                        sheet.Cells[j, 5].Value ==
                        " Не полная") //If there is slot => add panel, else => add new task
                    {
                        sheet.Cells[i, 4].Value += panel.name + ", ";
                        if (i == CarCapacity) sheet.Cells[j, 5].Value = "Полная";
                        else sheet.Cells[j, 5].Value = "Не полная";
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    sheet.Cells[rowCount + 1, 1].Value = panel.date;
                    sheet.Cells[rowCount + 1, 2].Value = CarNum;
                    sheet.Cells[rowCount + 1, 3].Value = panel.destination;
                    sheet.Cells[rowCount + 1, 4].Value += panel.name + ", ";
                }
            }
            
            var reportExcel = package.GetAsByteArray();
            File.WriteAllBytes(ExcelPath, reportExcel);
        }


        private void AddNotSent(string destination, string[] resources, DateTime date)
        {
            foreach (var t in resources)
            {
                PanelsQueue.Enqueue(new Panel(t, destination, date));
            }
        }

        public void Init(string FilePath, CheckBox IsProtected, string ExcelSavePath, CheckBox IsWarn, ProgressBar progress)
        {
            MessageBox.Show("Начало работы.", "Движение 360");
            string ExcelName = DateTime.Today.ToShortDateString();
            CreateSheet(ExcelSavePath, ExcelName); //Add new sheet

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; //License init
            FileInfo existingFile = new FileInfo(FilePath);
            using ExcelPackage package = new ExcelPackage(existingFile);
            //get the worksheet in the workbook
            ExcelWorksheet worksheet = package.Workbook.Worksheets[3]; //Change sheet
            int rowCount = worksheet.Dimension.End.Row;
            int colCount = worksheet.Dimension.End.Column;
            progress.Maximum = rowCount - 1 * colCount;
            for (int i = 2; i <= colCount; i++)
            {
                int x = 0;
                while (x != PanelsQueue.Count)
                {
                    string CarNum = GetAvalibleCar(FilePath, 0).Item1; //Get car num
                    int CarCapacity = int.Parse(GetAvalibleCar(FilePath, 0).Item2); //Get car capacity
                    Generate(ExcelSavePath, CarNum, CarCapacity);
                    x++;
                }
                for (int j = 2; j <= rowCount; j++)
                {
                    Update(FilePath, ExcelSavePath, j, i, IsWarn);
                    Action action = () => { progress.Value++; };
                    action.BeginInvoke(null, null);
                }

                ResetCars(FilePath, 0);
            }

            SetStyle(ExcelSavePath, IsProtected);
        }

        private static void SetStyle(string FilePath, CheckBox IsProtected)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; //License init
            FileInfo existingFile = new FileInfo(FilePath);
            using ExcelPackage package = new ExcelPackage(existingFile);
            var sheet = package.Workbook.Worksheets[0];
            int rowCount = sheet.Dimension.End.Row; //Get row count
            int colCount = sheet.Dimension.End.Column; //Get row count
            if (IsProtected.IsChecked == true)
            {
                int seed = DateTime.Now.Minute + DateTime.Now.Day + DateTime.Now.Month + DateTime.Now.Hour +
                           DateTime.Now.Minute + DateTime.Now.Second + DateTime.Now.Millisecond +
                           DateTime.Now.Year; //Generate seed
                Random random = new Random(seed);
                string code = "";
                for (int i = 0; i < 10; i++)
                {
                    int r = random.Next(48, 89);
                    code += (char)r;
                }

                sheet.Protection.IsProtected = true; //Protection
                sheet.Protection.SetPassword(code); //Set pass
                MessageBox.Show("Пароль для таблицы: " + code);
            }

            sheet.Cells[1, 1, rowCount, colCount].AutoFitColumns(); //Autosize
            sheet.Cells[1, 1, rowCount, 1].Style.Font.Bold = true; //Bold date column
            sheet.Cells[1, 1, rowCount, colCount].AutoFitColumns(); //Autosize

            File.WriteAllBytes(FilePath, package.GetAsByteArray());
        }

        private void Update(string FilePath, string ExcelSavePath, int row, int col, CheckBox IsWarn)
        {
            string destination = GetNeededResources(FilePath, 3, row, col).Item1; //Get destination
            string[] resources = GetNeededResources(FilePath, 3, row, col).Item2; //Get needed resouces for obj
            date = GetNeededResources(FilePath, 3, row, col).Item3; //Get date for obj
            if (resources == null) return;
            string CarNum = GetAvalibleCar(FilePath, 0).Item1; //Get car num
            int CarCapacity = int.Parse(GetAvalibleCar(FilePath, 0).Item2); //Get car capacity

            foreach (var t in resources)
            {
                PanelsQueue.Enqueue(new Panel(t, destination, date));
            }
            
            if (string.IsNullOrEmpty(CarNum))
            {
                if (IsWarn.IsChecked == true)
                {
                    MessageBox.Show("На " + date.ToShortDateString() + " больше нет свободных машин.\n" +
                                    "Недоставленные панели будут как можно быстрее доставлены " +
                                    date.AddDays(1).ToShortDateString() + " ");
                }

                AddNotSent(destination, resources, date); //Write unused panels
            }
            else
            {
                Generate(ExcelSavePath, CarNum, CarCapacity);
                
            }
        }

    }
}