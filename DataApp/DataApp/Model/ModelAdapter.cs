using DataApp.DTO;
using System.Collections.Generic;

namespace DataApp.Model
{
    class ModelAdapter<T> where T : IContact, new()
    {
        public T ModelConvert(ViewContact model)
        {
            return new T()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber
            };
        }

        public IEnumerable<ViewContact> ToViewContacListConvert(IEnumerable<IContact> contacts)
        {
            List<ViewContact> viewContacts = new List<ViewContact>();

            foreach (var item in contacts)
            {
                viewContacts.Add(
                    new ViewContact
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        PhoneNumber = item.PhoneNumber
                    });
            }
            return viewContacts;
        }
    }
}
