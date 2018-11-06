using DataApp.ViewModel;
using System;
using Xamarin.Forms;

namespace DataApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ContactViewModel() { Navigation = this.Navigation };

            btnFind.Clicked += FindByName_Clecked;
            btnX.Clicked += ResetSort_Clecked;
            btnRealm.Clicked += SwichOnRealmDb_Clecked;
            btnSQLite.Clicked += SwichOnSQLiteDb_Clecked;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            btnFind.IsVisible = true;
            btnX.IsVisible = false;
            entryFind.Text = "";
        }

        private void SwichOnRealmDb_Clecked(object sendr, EventArgs argEvent)
        {
            btnX.IsVisible = false;
            entryFind.Text = "";
            btnRealm.BorderWidth = 2;
            btnSQLite.BorderWidth = 0;
            btnRealm.TextColor = Color.Black;
            btnSQLite.TextColor = Color.Gray;
        }

        private void SwichOnSQLiteDb_Clecked(object sendr, EventArgs argEvent)
        {
            btnX.IsVisible = false;
            entryFind.Text = "";
            btnRealm.BorderWidth = 0;
            btnSQLite.BorderWidth = 2;
            btnRealm.TextColor = Color.Gray;
            btnSQLite.TextColor = Color.Black;
        }

        private void FindByName_Clecked(object sendr, EventArgs argEvent)
        {
            btnX.IsVisible = true;
            btnFind.IsVisible = false;
        }

        private void ResetSort_Clecked(object sendr, EventArgs argEvent)
        {
            btnX.IsVisible = false;
            btnFind.IsVisible = true;
            entryFind.Text = "";
        }
    }
}
