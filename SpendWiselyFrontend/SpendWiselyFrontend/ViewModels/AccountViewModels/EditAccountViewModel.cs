using SpendWiselyFrontend.ClientServices.Abstractions;
using SpendWiselyFrontend.Dtos;
using SpendWiselyFrontend.ViewModels.Abstractions;


namespace SpendWiselyFrontend.ViewModels.AccountViewModels
{
    public class EditAccountViewModel : BaseSingleViewModel<AccountDto, IMoneyAccountService> { }
}
