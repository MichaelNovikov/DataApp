using DataApp.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataApp.DataController
{
    public interface IDataBase
    {
        void Create(IContact obj);
        IEnumerable<IContact> ReadAll();
        IEnumerable<IContact> ReadAllByName(string name);
        void Update(IContact source);
        void Delete(string id);
    }
}
