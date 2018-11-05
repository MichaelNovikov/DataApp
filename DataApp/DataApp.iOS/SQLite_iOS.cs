using System;
using Xamarin.Forms;
using System.IO;
using DataApp.DataController;
using Foundation;
using UIKit;
using DataApp.iOS;

[assembly: Dependency(typeof(SQLite_iOS))]
namespace DataApp.iOS
{
    public class SQLite_iOS : ISQLite
    {
        public SQLite_iOS() { }
        public string GetDatabasePath(string sqliteFileName)
        {
            // определяем путь к бд
            string documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentsPath, "..", "Library"); // папка библиотеки
            var path = Path.Combine(libraryPath, sqliteFileName);

            return path;
        }
    }
}