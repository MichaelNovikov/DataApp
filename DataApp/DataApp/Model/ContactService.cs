using DataApp.DataController;
using DataApp.DTO;
using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataApp.Model
{
    class ContactService
    {
        private RealmImplementation<Contact> _realmInst;

        public ContactService()
        {
            _realmInst = new RealmImplementation<Contact>();
        }

        public IEnumerable<Contact> GetCollection()
        {
            return _realmInst.Read();
        }

        public void AddContact(Contact contact)
        {
            _realmInst.Create(contact);
        }

        public void DeleteContact(string id)
        {
            _realmInst.Delete(id);
        }

        public void UpdateContact(Contact contact)
        {
            _realmInst.Update(contact);
        }
    }
}
