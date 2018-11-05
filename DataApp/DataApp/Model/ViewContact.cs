using DataApp.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataApp.Model
{
    class ViewContact
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ViewPhone PhoneNumber { get; set; }
    }
}
