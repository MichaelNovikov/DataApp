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
	public partial class UpdateDeleteContactPage : ContentPage
	{
		public UpdateDeleteContactPage (ContactViewModel contactViewModel)
		{
			InitializeComponent ();
            BindingContext = contactViewModel;
        }
	}
}