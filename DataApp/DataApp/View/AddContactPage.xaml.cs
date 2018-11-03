using DataApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DataApp.View
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddContactPage : ContentPage
	{
		public AddContactPage (ContactViewModel contactViewModel)
		{
			InitializeComponent ();
            BindingContext = contactViewModel;
        }
	}
}