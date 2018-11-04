using System;
using System.Collections.Generic;
using System.Text;

namespace DataApp.DTO
{
    
    class SQLiteContact : IContact
    {
        public string Id { get ; set ; }
        public string FirstName { get ; set ; }
        public string LastName { get ; set ; }
        public Phone PhoneNumber { get ; set ; }
    }
}
