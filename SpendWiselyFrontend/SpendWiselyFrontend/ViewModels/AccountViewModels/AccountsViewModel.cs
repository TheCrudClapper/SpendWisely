using Microsoft.Extensions.DependencyInjection;
using SpendWiselyFrontend.ClientServices;
using SpendWiselyFrontend.ClientServices.Abstractions;
using SpendWiselyFrontend.Dtos;
using SpendWiselyFrontend.ViewModels.Abstractions;
using SpendWiselyFrontend.Views.AccountViews;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SpendWiselyFrontend.ViewModels.AccountViewModels
{
    public class AccountsViewModel : BaseManyViewModel<AccountDto, IMoneyAccountService>
    {
        protected override async void OpenAddPage()
        {
            await Shell.Current.GoToAsync($"/{nameof(AddAccountPage)}");
        }
        protected override async Task OpenEditPage(AccountDto account)
        {
            if (account == null) return;
            await Shell.Current.GoToAsync($"{nameof(EditAccountPage)}?accountId={account.Id}");
        }
    }
}
