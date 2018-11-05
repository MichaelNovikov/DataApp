using DataApp.DTO;
using Realms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataApp.DataController
{
    class RealmImplementation<T> : IDataBase<T> where T: RealmObject
    {
        private Realm _instance;

        public RealmImplementation()
        {
            var config = new RealmConfiguration() { SchemaVersion = 1 };
            _instance = Realm.GetInstance(config);
        }

        public void Create(T obj)
        {
            _instance.Write(() =>
            {
                _instance.Add(obj);
            });
        }

        public void Delete(string id)
        {
            _instance.Write(() =>
            {
                _instance.Remove(_instance.Find<T>(id));
            });
        }

        public IEnumerable<T> Read()
        {
            return _instance.All<T>();
        }

        public void Update(T source)
        {
            _instance.Write(() =>
            {
                _instance.Add(source, true);
            });
        }
    }
}
