using DataApp.DTO;
using Realms;
using System.Collections.Generic;

namespace DataApp.DataController
{
    class RealmImplementation : IDataBase
    {
        private Realm _instance;

        public RealmImplementation()
        {
            var config = new RealmConfiguration() { SchemaVersion = 1 };
            _instance = Realm.GetInstance(config);
        }

        public void Create(IContact obj)
        {
            _instance.Write(() =>
            {
                _instance.Add(obj as RealmContact);
            });
        }

        public void Delete(string id)
        {
            _instance.Write(() =>
            {
                _instance.Remove(_instance.Find<RealmContact>(id));
            });
        }

        public IEnumerable<IContact> Read()
        {
            return _instance.All<RealmContact>() as IEnumerable<IContact>;
        }

        public void Update(IContact source)
        {
            _instance.Write(() =>
            {
                _instance.Add(source as RealmContact, true);
            });
        }
    }
}
