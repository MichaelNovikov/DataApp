using DataApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace DataApp
{
    public partial class MainPage : ContentPage
    {
        public static Button _resetSort;
        public static Entry _entryFind;
        public MainPage()
        {
            InitializeComponent();
            BindingContext = new ContactViewModel() { Navigation = this.Navigation };
            _resetSort = btnX;
            _entryFind = entryFind;
        }
    }
}
