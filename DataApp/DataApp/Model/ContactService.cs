using DataApp.DataController;
using DataApp.DTO;
using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataApp.Model
{
    class ContactService<T> where T : IContact, new()
    {
        IDataBase _dataBase;

        private ModelAdapter<T> adapter = new ModelAdapter<T>(); 

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
            T realContact = adapter.ModelConvert(contact);
            _dataBase.Create(realContact);
        }

        public void DeleteContact(string id)
        {
            _dataBase.Delete(id);
        }

        public void UpdateContact(IContact contact)
        {
            T realContact = adapter.ModelConvert(contact);
            _dataBase.Update(realContact);
        }
    }
}
