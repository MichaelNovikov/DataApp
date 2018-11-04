using DataApp.DataController;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataApp.DAL
{
    class DbDal<T>
    {
        private IDataBase<T> _dataBase;

        public DbDal(IDataBase<T> dataBase)
        {
            _dataBase = dataBase;
        }

        public IEnumerable<T> GetCollection()
        {
            return _dataBase.Read() as IEnumerable<T>;
        }

        public void AddContact(T contact)
        {
            _dataBase.Create(contact);
        }

        public void DeleteContact(string id)
        {
            _dataBase.Delete(id);
        }

        public void UpdateContact(T contact)
        {
            _dataBase.Update(contact);
        }
    }
}
