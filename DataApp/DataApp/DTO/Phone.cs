using Realms;

namespace DataApp.DTO
{
    public class Phone : RealmObject, IPhone
    {
        public string Number { get; set; }
    }
}