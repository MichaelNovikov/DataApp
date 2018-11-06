using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataApp.DTO
{
    [Table("SQLiteContacts")]
    class SQLiteContact : IContact
    {
        [PrimaryKey]
        public string Id { get ; set ; } = Guid.NewGuid().ToString();
        public string FirstName { get ; set ; }
        public string LastName { get ; set ; }
        public string PhoneNumber { get ; set ; }
    }
}
