﻿using DataApp.DataController;
using DataApp.DTO;
using DataApp.Model;
using DataApp.View;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace DataApp.ViewModel
{
    public class ContactViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private dynamic ContactService { get; set; }
        public IEnumerable<ViewContact> Contacts { get; set; }
        public ViewContact selectedItem;
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string FindProperty { get; set; }

        public INavigation Navigation { get; set; }
        public ICommand AddContactCommand { protected set; get; }
        public ICommand SaveNewContactCommand { protected set; get; }
        public ICommand DeleteContactCommand { protected set; get; }
        public ICommand UpdateContactCommand { protected set; get; }
        public ICommand FindByNameCommand { protected set; get; }
        public ICommand ResetSortCommand { protected set; get; }
        public ICommand SwichOnRealmDbCommand { protected set; get; }
        public ICommand SwichOnSQLiteDbCommand { protected set; get; }

        public ContactViewModel()
        {
            ContactService = new ContactService<RealmContact>(new RealmImplementation());
            Contacts = ContactService.GetCollection();
            AddContactCommand = new Command(AddContact);
            SaveNewContactCommand = new Command(SaveNewContact);
            DeleteContactCommand = new Command(DeleteContact);
            UpdateContactCommand = new Command(UpdateContact);
            FindByNameCommand = new Command(FindByName);
            ResetSortCommand = new Command(ResetSort);
            SwichOnRealmDbCommand = new Command(SwichOnRealmDb);
            SwichOnSQLiteDbCommand = new Command(SwichOnSQLiteDb);          
        }

        public ViewContact SelectedItem
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
                PhoneNumber = selectedItem.PhoneNumber;
                
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
            if (!((FirstName == null) && (LastName == null) && (PhoneNumber == null)))
            {
                ContactService.AddContact(new ViewContact
                {
                    FirstName = this.FirstName,
                    LastName = this.LastName,
                    PhoneNumber = this.PhoneNumber 
                });

                Contacts = ContactService.GetCollection();
                OnPropertyChanged("Contacts");
            }
            Navigation.PopAsync();
        }

        private void UpdateContact()
        {
            var contact = new ViewContact
            {
                Id = this.Id,
                FirstName = this.FirstName,
                LastName = this.LastName,
                PhoneNumber = this.PhoneNumber
            };
            ContactService.UpdateContact(contact);

            Contacts = ContactService.GetCollection();
            OnPropertyChanged("Contacts");
            Navigation.PopAsync();
        }

        private void DeleteContact()
        {
            ContactService.DeleteContact(Id);

            Contacts = ContactService.GetCollection();
            OnPropertyChanged("Contacts");
            Navigation.PopAsync();
        }

        private void FindByName()
        {
            Contacts = ContactService.GetCollectionByName(FindProperty);
            OnPropertyChanged("Contacts");
            Navigation.PopAsync();
        }

        private void ResetSort()
        {
            Contacts = ContactService.GetCollection();
            OnPropertyChanged("Contacts");
            Navigation.PopAsync();
        }

        private void SwichOnRealmDb()
        {
            ContactService = new ContactService<RealmContact>(new RealmImplementation());
            Contacts = ContactService.GetCollection();
            OnPropertyChanged("Contacts");
            Navigation.PopAsync();
        }

        private void SwichOnSQLiteDb()
        {
            ContactService = new ContactService<SQLiteContact>(new SQLiteImplementation());
            Contacts = ContactService.GetCollection();
            OnPropertyChanged("Contacts");
            Navigation.PopAsync();
        }

        protected void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
