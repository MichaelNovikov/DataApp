using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DataApp.DataController
{
    class SQLiteImplementation<T> : IDataBase<T> where T: new()
    {
        SQLiteConnection _database;

        public SQLiteImplementation()
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath("SQLiteContacts.db");
            _database = new SQLiteConnection(databasePath);
            _database.CreateTable<T>();
        }

        public void Create(T obj)
        {
            _database.Insert(obj);
        }

        public void Delete(string id)
        {
            _database.Delete<T>(id);
        }

        public IEnumerable<T> Read()
        {
            return _database.Table<T>();
        }

        public void Update(T source)
        {
            _database.Update(source);
        }
    }
}
