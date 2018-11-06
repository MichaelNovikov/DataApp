using DataApp.ViewModel;
using Xamarin.Forms;

namespace DataApp
{
    public partial class MainPage : ContentPage
    {
        public static Button _resetSort;
        public static Button _btnFind;
        public static Entry _entryFind;
        public static Button _btnRealm;
        public static Button _btnSQLite;

        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ContactViewModel() { Navigation = this.Navigation };
            _btnFind = btnFind;
            _resetSort = btnX;
            _entryFind = entryFind;
            _btnRealm = btnRealm;
            _btnSQLite = btnSQLite;
        }
    }
}
