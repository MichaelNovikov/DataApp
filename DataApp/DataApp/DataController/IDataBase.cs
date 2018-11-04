using System;
using System.Collections.Generic;
using System.Text;

namespace DataApp.DataController
{
    interface IDataBase<T>
    {
        void Create(T obj);
        IEnumerable<T> Read(Func<T, bool> predicate);
        IEnumerable<T> Read();
        void Update(T source);
        void Delete(string id);
    }
}
