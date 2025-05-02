using System;
using System.Collections.Generic;
using SpendWiselyFrontend.ViewModels.Abstractions;
using System.Text;
using SpendWiselyFrontend.Dtos;
using System.Threading.Tasks;
using Xamarin.Forms;
using SpendWiselyFrontend.Views.AccountViews;
using SpendWiselyFrontend.Views.BudgetViews;

namespace SpendWiselyFrontend.ViewModels.BudgetViewModels
{
    public class BudgetsViewModel
    {
        private readonly IRestService _restService;
        public Command OpenAddBudgetPageCommand { get; set; }
        public BudgetsViewModel(ClientServices.RestService restService)
        {
            _restService = restService;
            OpenAddBudgetPageCommand = new Command(OpenAddBudgettPage);
        }
        public BudgetsViewModel()
        {
            
        }
        //public override Task LoadItemsAsync()
        //{
            
        //}
        private async void OpenAddBudgettPage()
        {
            await Shell.Current.GoToAsync($"/{nameof(AddBudgetPage)}");
        }
        
    }
}
