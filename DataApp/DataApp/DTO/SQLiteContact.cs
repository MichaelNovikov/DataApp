using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataApp.DTO
{
    [Table("SQLiteContacts")]
    class SQLiteContact : IContact
    {
        [PrimaryKey, AutoIncrement]
        public string Id { get ; set ; }
        public string FirstName { get ; set ; }
        public string LastName { get ; set ; }
        public Phone PhoneNumber { get ; set ; }
    }
}
