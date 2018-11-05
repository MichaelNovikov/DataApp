using DataApp.DTO;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace DataApp.DataController
{
    class SQLiteImplementation : IDataBase
    {
        SQLiteConnection _database;

        public SQLiteImplementation()
        {
            string databasePath = DependencyService.Get<ISQLite>().GetDatabasePath("SQLiteContacts.db");
            _database = new SQLiteConnection(databasePath);
            _database.CreateTable<SQLiteContact>();
        }

        public void Create(IContact obj)
        {
            _database.Insert(obj as SQLiteContact);
        }

        public void Delete(string id)
        {
            _database.Delete<SQLiteContact>(id);
        }

        public IEnumerable<IContact> Read()
        {
            return _database.Table<SQLiteContact>() as IEnumerable<IContact>;
        }

        public void Update(IContact source)
        {
            _database.Update(source as SQLiteContact);
        }
    }
}
