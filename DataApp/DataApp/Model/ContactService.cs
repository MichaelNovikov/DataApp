using DataApp.DAL;
using DataApp.DataController;
using DataApp.DTO;
using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataApp.Model
{
    class ContactService<T> where T : RealmObject, IContact
    {
        DbDal<T> _dbDal;

        public ContactService()
        {
            _dbDal = new DbDal<T>(new RealmImplementation<T>());
        }

        public IEnumerable<T> GetCollection()
        {
            return _dbDal.GetCollection();
        }

        public void AddContact(T contact)
        {
            _dbDal.AddContact(contact);
        }

        public void DeleteContact(string id)
        {
            _dbDal.DeleteContact(id);
        }

        public void UpdateContact(T contact)
        {
            _dbDal.UpdateContact(contact);
        }
    }
}
