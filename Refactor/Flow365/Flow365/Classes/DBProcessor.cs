using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using Microsoft.Data.Sqlite;

namespace Flow365.Classes
{
    static class DBProcessor
    {
        // Fields
        public static DateTime startOfWorkDate;
        public static DateTime endOfWorkDate;
        public static int floorsCount;
        public static string folderPath;


        public static void GenerateDB()
        {
            CreateFolder();
            CreateDB();

            SqliteConnection connection = new SqliteConnection("Data Source=flow.db");

            CreateTable(connection, "CREATE TABLE [Cars] ([id] INTEGER NOT NULL UNIQUE, [name] TEXT NOT NULL, [IsAvalible] BOOLEAN NOT NULL DEFAULT [true], PRIMARY KEY([id] AUTOINCREMENT));");
            CreateTable(connection, "CREATE TABLE [Panels] ([id] INTEGER NOT NULL UNIQUE, [name] TEXT NOT NULL, [count] INTEGER NOT NULL DEFAULT 0, PRIMARY KEY([id] AUTOINCREMENT));");
            CreateTable(connection, "CREATE TABLE [Destinations] ([id] INTEGER NOT NULL UNIQUE, [address] TEXT NOT NULL, [needed_panels] TEXT NOT NULL DEFAULT [{}], PRIMARY KEY([id] AUTOINCREMENT));");
            CreateTable(connection, "CREATE TABLE [Output] ([id] INTEGER NOT NULL UNIQUE, [date] TEXT NOT NULL, [car_id] INTEGER NOT NULL, [destination_id] INTEGER NOT NULL, [panels] TEXT NOT NULL DEFAULT [{}], PRIMARY KEY([id] AUTOINCREMENT), FOREIGN KEY([car_id]) REFERENCES [Cars]([id]), FOREIGN KEY([destination_id]) REFERENCES [Destinations]([id]));");
        }

        static void CreateFolder()
        {
            folderPath = $"{folderPath}/{DateTime.Today.ToShortDateString}";
            Directory.CreateDirectory(folderPath);
        }

        static void CreateDB()
        {
            if (!File.Exists(@$"{folderPath}\flow.db"))
            {
                SQLiteConnection.CreateFile(@$"{folderPath}\flow.db");
            }
        }

        static void CreateTable(SqliteConnection connection, string query)
        {
            SqliteCommand command = new SqliteCommand();
            command.CommandText = query;
            command.Connection = connection;
            command.ExecuteNonQuery();
        }
    }
}

