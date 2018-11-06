using DataApp.DTO;
using Realms;
using System.Collections.Generic;
using System.Linq;

namespace DataApp.DataController
{
    class RealmImplementation : IDataBase
    {
        private Realm _instance;

        public RealmImplementation()
        {
            var config = new RealmConfiguration() { SchemaVersion = 2 };
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

        public IEnumerable<IContact> ReadAll()
        {
            return _instance.All<RealmContact>() as IEnumerable<IContact>;
        }

        public IEnumerable<IContact> ReadAllByName(string name)
        {
            return _instance.All<RealmContact>().Where(c => c.FirstName == name);
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
