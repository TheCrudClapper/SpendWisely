using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpendWiselyFrontend.ViewModels.CategoriesViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpendWiselyFrontend.Views.CategoryViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CategoriesPage : ContentPage
	{
		public CategoriesPage ()
		{
			InitializeComponent ();
			this.BindingContext = new CategoriesViewModel();
		}
	}
}