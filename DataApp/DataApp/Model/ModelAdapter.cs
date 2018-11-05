using DataApp.DTO;

namespace DataApp.Model
{
    class ModelAdapter<T> where T : IContact, new()
    {
        public T ModelConvert(IContact model)
        {
            return new T()
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                PhoneNumber = model.PhoneNumber
            };
        }
    }
}
