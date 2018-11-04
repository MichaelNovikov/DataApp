using DataApp.DTO;
using DataApp.Model;
using DataApp.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace DataApp.ViewModel
{
    public class ContactViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ContactService ContactService { get; set; }
        public IQueryable<Contact> Contacts { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
        public Contact selectedItem;


        public INavigation Navigation { get; set; }
        public ICommand AddContactCommand { protected set; get; }
        public ICommand SaveNewContactCommand { protected set; get; }
        public ICommand DeleteContactCommand { protected set; get; }
        public ICommand UpdateContactCommand { protected set; get; }

        public ContactViewModel()
        {
            ContactService = new ContactService();
            Contacts = ContactService.GetCollection() as IQueryable<Contact>;
            AddContactCommand = new Command(AddContact);
            SaveNewContactCommand = new Command(SaveNewContact);
            DeleteContactCommand = new Command(DeleteContact);
            UpdateContactCommand = new Command(UpdateContact);
        }

        public Contact SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;

                if (selectedItem == null)
                    return;
                Id = selectedItem.Id;
                FirstName = selectedItem.FirstName;
                LastName = selectedItem.LastName;
                Number = SelectedItem.PhoneNumber.Number;

                Navigation.PushAsync(new UpdateDeleteContactPage(this));
                SelectedItem = null;
            }
        }

        private void AddContact()
        {
            Navigation.PushAsync(new AddContactPage(this));
        }

        private void SaveNewContact()
        {
            if (!((FirstName == null) && (LastName == null) && (Number == null)))
            {
                ContactService.AddContact(new Contact
                {
                    FirstName = this.FirstName,
                    LastName = this.LastName,
                    PhoneNumber = new Phone { Number = this.Number }
                });

                Contacts = ContactService.GetCollection() as IQueryable<Contact>;
                OnPropertyChanged("Contacts");
            }
            Navigation.PopAsync();
        }

        private void UpdateContact()
        {
            var contact = new Contact
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                PhoneNumber = new Phone { Number = this.Number }
            };
            ContactService.UpdateContact(contact);

            Contacts = ContactService.GetCollection() as IQueryable<Contact>;
            OnPropertyChanged("Contacts");
            Navigation.PopAsync();
        }

        private void DeleteContact()
        {
            ContactService.DeleteContact(Id);

            Contacts = ContactService.GetCollection() as IQueryable<Contact>;
            OnPropertyChanged("Contacts");
            Navigation.PopAsync();
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
