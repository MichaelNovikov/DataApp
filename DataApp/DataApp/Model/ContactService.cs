using DataApp.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataApp.Model
{
    class ContactService
    {
        public  List<Contact> _list;

        public ContactService()
        {
            _list = new List<Contact>();
            ListInit();
        }

        private void ListInit()
        {
            for (int i = 0; i < 15; i++)
            {
                _list.Add(new Contact
                {
                    FirstName = "Ivan",
                    LastName = "Ivanov",
                    PhoneNumber = new Phone { Number = "+38 073 36 73 478" }
                });
            }
        }

        //public List<Contact> ContactList
        //{
        //    get { return _list; }
        //}
    }
}
