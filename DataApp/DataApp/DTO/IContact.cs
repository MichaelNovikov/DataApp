using System;
using System.Collections.Generic;
using System.Text;

namespace DataApp.DTO
{
    public interface IContact
    {
        string Id { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string PhoneNumber { get; set; }
    }
}
