using SpendWiselyFrontend.ViewModels.AccountViewModels;
using SpendWiselyFrontend.ViewModels.CategoriesViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpendWiselyFrontend.Views.CategoryViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(CategoryId), "accountId")]
    public partial class EditCategoryPage : ContentPage
	{
        public string CategoryId
        {
            set
            {
                var vm = BindingContext as EditCategoryViewModel;
                vm?.LoadItem(int.Parse(value));
            }
        }
        public EditCategoryPage ()
		{
			InitializeComponent ();
            this.BindingContext = new EditCategoryViewModel();
        }
	}
}