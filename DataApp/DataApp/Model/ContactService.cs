using DataApp.DataController;
using DataApp.DTO;
using System.Collections.Generic;

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

        public IEnumerable<ViewContact> GetCollection()
        {
            return adapter.ToViewContacListConvert(_dataBase.ReadAll());
        }

        public IEnumerable<ViewContact> GetCollectionByName(string name)
        {
            return adapter.ToViewContacListConvert(_dataBase.ReadAllByName(name));
        }

            public void AddContact(ViewContact contact)
        {
            IContact realContact = adapter.ModelConvert(contact);
            _dataBase.Create(realContact);
        }

        public void DeleteContact(string id)
        {
            _dataBase.Delete(id);
        }

        public void UpdateContact(ViewContact contact)
        {
            IContact realContact = adapter.ModelConvert(contact);
            _dataBase.Update(realContact);
        }
    }
}
