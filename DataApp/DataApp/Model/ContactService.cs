using DataApp.DataController;
using DataApp.DTO;
using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataApp.Model
{
    class ContactService<T> 
    {
        IDataBase _dataBase;

        public ContactService(IDataBase dataBase)
        {
            _dataBase = dataBase;
        }

        public IEnumerable<T> GetCollection()
        {
            return _dataBase.Read() as IEnumerable<T>;
        }

        public void AddContact(IContact contact)
        {
            _dataBase.Create(contact);
        }

        public void DeleteContact(string id)
        {
            _dataBase.Delete(id);
        }

        public void UpdateContact(IContact contact)
        {
            _dataBase.Update(contact);
        }
    }
}
