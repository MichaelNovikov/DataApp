using System;
using System.Collections.Generic;
using System.Text;

namespace DataApp.DataController
{
    public interface ISQLite
    {
        string GetDatabasePath(string sqliteFileName);
    }
}
