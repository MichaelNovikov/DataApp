using DataApp.DTO;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DataApp.DataController
{
    class SQLiteImplementation<T> : IDataBase where T: class, new()
    {
        SQLiteConnection _database;

        public SQLiteImplementation()
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath("SQLiteContacts.db");
            _database = new SQLiteConnection(databasePath);
            _database.CreateTable<T>();
        }

        public void Create(IContact obj)
        {
            _database.Insert(obj as T);
        }

        public void Delete(string id)
        {
            _database.Delete<T>(id);
        }

        public IEnumerable<IContact> Read()
        {
            return _database.Table<T>() as IEnumerable<IContact>;
        }

        public void Update(IContact source)
        {
            _database.Update(source as T);
        }
    }
}
