using DataApp.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataApp.DataController
{
    public interface IDataBase
    {
        void Create(IContact obj);
        IEnumerable<IContact> Read();
        void Update(IContact source);
        void Delete(string id);
    }
}
