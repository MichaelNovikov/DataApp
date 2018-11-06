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

        public IEnumerable<IContact> ReadAll()
        {
            return _database.Table<SQLiteContact>();
        }

        public IEnumerable<IContact> ReadAllByName(string name)
        {
            return _database.Query<SQLiteContact>("SELECT * FROM SQLiteContacts WHERE FirstName = ?", name);
        }

        public void Update(IContact source)
        {
            _database.Update(source as SQLiteContact);
        }
    }
}
