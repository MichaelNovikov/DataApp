using DataApp.DTO;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataApp.DataController
{
    class RealmImplementation<T> : IDataBase where T: RealmObject
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
                _instance.Add(obj as T);
            });
        }

        public void Delete(string id)
        {
            _instance.Write(() =>
            {
                _instance.Remove(_instance.Find<T>(id));
            });
        }

        public IEnumerable<IContact> Read()
        {
            return _instance.All<T>() as IEnumerable<IContact>;
        }

        public void Update(IContact source)
        {
            _instance.Write(() =>
            {
                _instance.Add(source as T, true);
            });
        }
    }
}
