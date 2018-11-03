using DataApp.DTO;
using DataApp.Model;
using DataApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DataApp.ViewModel
{
    public class ContactViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ContactService ContactService { get; set; }
        public List<Contact> Contacts { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }


        public INavigation Navigation { get; set; }
        public ICommand AddContactCommand { protected set; get; }
        public ICommand SaveContactCommand { protected set; get; }

        public ContactViewModel()
        {
            ContactService = new ContactService();
            Contacts = ContactService._list;
            AddContactCommand = new Command(AddContact);
            SaveContactCommand = new Command(SaveContact);
        }

        private void AddContact()
        {
            FirstName = "";
            LastName = "";
            Number = "";
            Navigation.PushAsync(new AddContactPage(this));
        }

        private void SaveContact()
        {
            if(!((FirstName == null) && (LastName == null) && (Number == null)))
            {
                var list = new List<Contact>();
                list.AddRange(Contacts);

                list.Add(new Contact
                {
                    FirstName = this.FirstName,
                    LastName = this.LastName,
                    PhoneNumber = new Phone { Number = this.Number }
                });
                Contacts = list;

                OnPropertyChanged("Contacts");
            }
            Navigation.PopAsync();
        }

        protected void OnPropertyChanged(string propName)
        {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
