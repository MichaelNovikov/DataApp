using System;
using System.Collections.Generic;
using System.Text;

namespace DataApp.DataController
{
    public interface IDataBase<T>
    {
        void Create(T obj);
        IEnumerable<T> Read();
        void Update(T source);
        void Delete(string id);
    }
}
