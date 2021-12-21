using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Microsoft.Win32;

using ExcelFileConfigurator.Classes;
using System.IO;

namespace ExcelFileConfigurator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        private static string ExcelPath = "";
        private static string ExcelSavePath = "";
        private const string Filter = "Files | *.xlsx; *.xlsb; *.xlsm; *.xlsb; *.xltx; *.xltm; *.xls; *.xlt; *.xls; *.xml; *.xml; *.xlam; *.xla; *.xlw; *.xlr";

        public MainWindow()
        {
            InitializeComponent();
            DateTime dateTime = DateTime.Today;
            CurrentDate.Text = dateTime.ToShortDateString();
        }

        private void Calculate_Click(object sender, RoutedEventArgs e)
        {
            if (ExcelPath != "")
            {
                ExcelSavePath = SaveFile(Filter, "Выберите куда сохранить таблицу");
                MessageBox.Show("Закройте файл выбранной вами таблицы!", "Движение 360");

                Data data = new Data();
                data.Init(ExcelPath, IsProtected, ExcelSavePath, IsWarn, Progress);
                //data.Init(ExcelPath, IsProtected, ExcelSavePath);

                MessageBox.Show("Успешно!", "Движение 360");
            }
            else
            {
                MessageBox.Show("Выберите исходную таблицу", "Движение 360: ОШИБКА");
            }
        }
        private void LoadExcel_Click(object sender, RoutedEventArgs e)
        {
            ExcelPath = ChooseFile(Filter, "Выберите файл таблицы", LoadExcel);
        }

        private static string ChooseFile(string Filter, string Title, Button Btn)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = Filter,
                Title = Title
            };
            if (ofd.ShowDialog() == true)
            {
                Btn.Background = new SolidColorBrush(Colors.Green);
                MessageBox.Show("Успешно!", "Движение 360");
                return ofd.FileName;
            }
            MessageBox.Show("Пожалуйста выберите файл.", "Движение 360: ОШИБКА");
            return "";
        }

        private static string SaveFile(string Filter, string Title)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = Filter,
                Title = Title
            };
            if (sfd.ShowDialog() == true)
            {
                MessageBox.Show("Успешно!", "Движение 360");
                return sfd.FileName;
            }
            MessageBox.Show("Выберите место сохранения файла!", "Движение 360: ОШИБКА");
            return "";
        }
        private void CreateBtn_Click(object sender, RoutedEventArgs e)
        {
            ExcelSavePath = SaveFile(Filter, "Выберите куда сохранить таблицу");

            if (int.TryParse(FloorCount.Text, out _) == false ||
                DateTime.TryParse(CurrentDate.Text, out _) == false ||
                DateTime.TryParse(DestinationDate.Text, out _) == false)
            {
                MessageBox.Show("Данные введены неправильно", "Движение 360: ОШИБКА");
            }
            else if (ExcelSavePath == "")
            {
                MessageBox.Show("Выберите место сохранения", "Движение 360: ОШИБКА");
            }
            else
            {
                var reportExcel = new ExcelGenerator().GenerateHeader(int.Parse(FloorCount.Text), CurrentDate.Text, DestinationDate.Text);
                File.WriteAllBytes(ExcelSavePath, reportExcel);
                MessageBox.Show("Успешно!", "Движение 360");
            }
        }
    }
}
