using SpendWiselyFrontend.ViewModels.IncomeViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SpendWiselyFrontend.Views.IncomeViews
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
    [QueryProperty(nameof(ItemId), "itemId")]
    public partial class EditIncomePage : ContentPage
	{
        public string ItemId
        {
            set
            {
                var vm = BindingContext as EditIncomeViewModel;
                vm?.LoadItem(int.Parse(value));

            }
        }
        public EditIncomePage()
        {
            InitializeComponent();
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            var vm = (EditIncomeViewModel)BindingContext;
            await vm?.LoadAccountList();
        }
    }
}