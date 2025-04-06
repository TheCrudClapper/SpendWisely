using System;
using System.Collections.Generic;
using System.Text;
using SpendWiselyFrontend.ClientServices;
using SpendWiselyFrontend.ViewModels.Abstractions;
namespace SpendWiselyFrontend.ViewModels.BudgetViewModels
{
    public class AddBudgetViewModel : BaseViewModel
    {
        private RestService _restService;

        public AddBudgetViewModel()
        {

        }
        public AddBudgetViewModel(RestService restService)
        {
            _restService = restService;
        }
        
    }
}
