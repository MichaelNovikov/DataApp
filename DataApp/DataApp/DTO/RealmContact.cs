using Realms;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataApp.DTO
{
    public class RealmContact : RealmObject, IContact
    {
        [PrimaryKey]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Phone PhoneNumber { get; set; }
    }
}
