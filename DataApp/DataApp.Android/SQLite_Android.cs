using System;
using System.IO;
using Xamarin.Forms;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DataApp.DataController;
using DataApp.Droid;

[assembly: Dependency(typeof(SQLite_Android))]
namespace DataApp.Droid
{
    public class SQLite_Android : ISQLite
    {
        public SQLite_Android() { }
        public string GetDatabasePath(string sqliteFilename)
        {
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, sqliteFilename);
            return path;
        }
    }
}