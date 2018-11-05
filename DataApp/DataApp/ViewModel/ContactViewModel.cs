using DataApp.DataController;
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

        private ContactService<RealmContact> ContactService { get; set; }
        public IQueryable<IContact> Contacts { get; set; }
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Number { get; set; }
        public IContact selectedItem;


        public INavigation Navigation { get; set; }
        public ICommand AddContactCommand { protected set; get; }
        public ICommand SaveNewContactCommand { protected set; get; }
        public ICommand DeleteContactCommand { protected set; get; }
        public ICommand UpdateContactCommand { protected set; get; }

        public ContactViewModel()
        {
            ContactService = new ContactService<RealmContact>(new RealmImplementation<RealmContact>());
            Contacts = ContactService.GetCollection() as IQueryable<IContact>;
            AddContactCommand = new Command(AddContact);
            SaveNewContactCommand = new Command(SaveNewContact);
            DeleteContactCommand = new Command(DeleteContact);
            UpdateContactCommand = new Command(UpdateContact);
        }

        public IContact SelectedItem
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
                ContactService.AddContact(new RealmContact
                {
                    FirstName = this.FirstName,
                    LastName = this.LastName,
                    PhoneNumber = new Phone { Number = this.Number }
                });

                Contacts = ContactService.GetCollection() as IQueryable<IContact>;
                OnPropertyChanged("Contacts");
            }
            Navigation.PopAsync();
        }

        private void UpdateContact()
        {
            var contact = new RealmContact
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                PhoneNumber = new Phone { Number = this.Number }
            };
            ContactService.UpdateContact(contact);

            Contacts = ContactService.GetCollection() as IQueryable<IContact>;
            OnPropertyChanged("Contacts");
            Navigation.PopAsync();
        }

        private void DeleteContact()
        {
            ContactService.DeleteContact(Id);

            Contacts = ContactService.GetCollection() as IQueryable<IContact>;
            OnPropertyChanged("Contacts");
            Navigation.PopAsync();
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
