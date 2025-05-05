using SpendWiselyFrontend.Dtos;
using SpendWiselyFrontend.Services.Abstractions;
using SpendWiselyFrontend.ViewModels.Abstractions;
using SpendWiselyFrontend.Views.AccountViews;
using SpendWiselyFrontend.Views.ExpenseViews;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SpendWiselyFrontend.ViewModels.ExpenseViewModels
{
    public class ExpensesViewModel : BaseManyViewModel<ExpenseDto, IExpenseService>
    {
        protected override async void OpenAddPage()
        {
            await Shell.Current.GoToAsync($"/{nameof(AddExpensePage)}");
        }
        protected override async Task OpenEditPage(ExpenseDto dto)
        {
            if (dto == null) return;
            await Shell.Current.GoToAsync($"{nameof(EditExpensePage)}?expenseId={dto.Id}");
        }
    }
}
