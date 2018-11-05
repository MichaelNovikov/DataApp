using DataApp.DTO;

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
                PhoneNumber = new Phone() { Number = model.PhoneNumber.Number}
            };
        }
    }
}
