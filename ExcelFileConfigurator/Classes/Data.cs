using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using OfficeOpenXml.Style;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Linq;

namespace ExcelFileConfigurator.Classes
{
    internal class Data
    {
        private bool _isEmpty = false;
        private bool _isNotSent = false;

        private Tuple<string?, string?> GetAvailableCar(string FilePath, int ExcelSheetNum)
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
                    if (worksheet.Cells?[i, 4].Value?.ToString() == "да")
                    {
                        if (worksheet.Cells != null)
                        {
                            worksheet.Cells[i, 4].Value = "нет";
                            var reportExcel = package.GetAsByteArray();
                            File.WriteAllBytes(FilePath, reportExcel);
                            return Tuple.Create(worksheet.Cells[i, 2].Value?.ToString(),
                                worksheet.Cells[i, 3].Value?.ToString());
                        }
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
            using ExcelPackage package = new ExcelPackage(existingFile);
            //get the worksheet in the workbook
            ExcelWorksheet worksheet = package.Workbook.Worksheets[ExcelSheetNum]; //Change sheet
            int rowCount = worksheet.Dimension.End.Row; //Get row count
            string[] arr = worksheet.Cells[row, col].Value?.ToString().Split(", ");
            string? name = worksheet.Cells[row, 1].Value?.ToString();
            DateTime date = DateTime.Parse(worksheet.Cells[1, col].Value?.ToString() ?? string.Empty);
            if (arr == null) _isEmpty = true;
            return Tuple.Create(name, arr, date);
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

        private void Generate(string ExcelSavePath, string CarNum, string[] panels, DateTime date, string name)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; //License init
            FileInfo existingFile = new FileInfo(ExcelSavePath);
            using ExcelPackage package = new ExcelPackage(existingFile);
            var sheet = package.Workbook.Worksheets[0];
            int rowCount = sheet.Dimension.End.Row; //Get row count
            int colCount = sheet.Dimension.End.Column; //Get row count

            sheet.Cells[rowCount + 1, 1].Value = date.ToShortDateString();
            sheet.Cells[rowCount + 1, 2].Value = CarNum;
            sheet.Cells[rowCount + 1, 3].Value = name;
            for (int i = 0; i < panels.Length; i++)
            {
                sheet.Cells[rowCount + 1, 4].Value += panels[i] + ", ";
                if (i + 1 != panels.Length) sheet.Cells[rowCount + 1, 3].Value += ", ";
            }


            var reportExcel = package.GetAsByteArray();
            File.WriteAllBytes(ExcelSavePath, reportExcel);
        }

        private void GeneratePrev(string ExcelPath, string FilePath, string CarNum)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; //License init
            string[] rowArr = File.ReadAllLines(FilePath);
            FileInfo existingFile = new FileInfo(ExcelPath);
            using ExcelPackage package = new ExcelPackage(existingFile);
            var sheet = package.Workbook.Worksheets[0];
            foreach (var t in rowArr)
            {
                string[] tempElementsArr = t.Split(" | ");

                int rowCount = sheet.Dimension.End.Row; //Get row count
                int colCount = sheet.Dimension.End.Column; //Get row count

                sheet.Cells[rowCount + 1, 1].Value = tempElementsArr[2];
                sheet.Cells[rowCount + 1, 2].Value = CarNum;
                sheet.Cells[rowCount + 1, 3].Value = tempElementsArr[0];
                sheet.Cells[rowCount + 1, 4].Value = tempElementsArr[1];
            }
        }

        private void WriteTemp(string FilePath, string name, string[] panels, DateTime date, int ps, int pe)
        {
            if (File.Exists(FilePath)) //Clear or create file
                File.Delete(FilePath);

            string txt = "";
            for (int i = ps; i < pe; i++)
            {
                txt += panels[i] + ", "; //Array to str
            }

            StreamWriter sw = new StreamWriter(FilePath, true);
            sw.WriteLine(name + " | " + txt + " | " + date.ToShortDateString()); //New line
            sw.Close();
        }

        public void Init(string FilePath, CheckBox IsProtected, string ExcelSavePath, CheckBox IsWarn)
        {
            MessageBox.Show("Начало работы.", "Движение 365");
            string ExcelName = DateTime.Today.ToShortDateString();
            CreateSheet(ExcelSavePath, ExcelName); //Add new sheet

            int rowCount;
            int colCount;

            ExcelPackage.LicenseContext = LicenseContext.NonCommercial; //License init
            FileInfo existingFile = new FileInfo(FilePath);
            using ExcelPackage package = new ExcelPackage(existingFile);
            //get the worksheet in the workbook
            ExcelWorksheet worksheet = package.Workbook.Worksheets[3]; //Change sheet
            rowCount = worksheet.Dimension.End.Row; //Get row count
            colCount = worksheet.Dimension.End.Column; //Get row count

            for (int i = 2; i <= colCount; i++)
            {
                for (int j = 2; j <= rowCount; j++)
                {
                    Update(FilePath, ExcelSavePath, j, i, IsWarn);
                }

                ResetCars(FilePath, 0);
            }

            SetStyle(ExcelSavePath, IsProtected);
        }

        private void SetStyle(string FilePath, CheckBox IsProtected)
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
            string CarNum = GetAvailableCar(FilePath, 0).Item1; //Get car num
            int CarCapacity = int.Parse(GetAvailableCar(FilePath, 0).Item2); //Get car capacity
            GeneratePrev(ExcelSavePath, "temp.txt", CarNum);
            string name = GetNeededResources(FilePath, 3, row, col).Item1; //Get obj name
            string[] resources = GetNeededResources(FilePath, 3, row, col).Item2; //Get needed resouces for obj
            DateTime date = GetNeededResources(FilePath, 3, row, col).Item3; //Get date for obj

            if (_isNotSent)
            {
                GeneratePrev(ExcelSavePath, "temp1.txt", CarNum);
                _isNotSent = false;
            }
            else if (_isEmpty == false)
            {
                if (CarCapacity == resources.Length)
                {
                    Generate(ExcelSavePath, CarNum, resources, date, name);
                }
                else if (CarCapacity < resources.Length)
                {
                    WriteTemp("temp1.txt", name, resources, date, CarCapacity, resources.Length);
                    _isNotSent = true;
                    Update(FilePath, ExcelSavePath, row, col, IsWarn);
                }
                else if (string.IsNullOrEmpty(CarNum))
                {
                    if (IsWarn.IsChecked == true)
                    {
                        MessageBox.Show("На " + date.ToShortDateString() + " больше нет свободных машин.\n" +
                                        "Недоставленные панели будут как можно быстрее доставлены " +
                                        date.AddDays(1).ToShortDateString() + " ");
                    }

                    _isNotSent = true;
                    WriteTemp("temp.txt", name, resources, date, 0, resources.Length); //Write unused panels
                    ResetCars(FilePath, 0);
                }
            }
            else
            {
                _isEmpty = false;
                return;
            }
        }
    }
}