using SpendWiselyFrontend.Dtos;
using SpendWiselyFrontend.Services.Abstractions;
using SpendWiselyFrontend.ViewModels.Abstractions;
using SpendWiselyFrontend.Views.AccountViews;
using SpendWiselyFrontend.Views.IncomeViews;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SpendWiselyFrontend.ViewModels.IncomeViewModels
{
    public class IncomesViewModel : BaseManyViewModel<IncomeDto, IIncomeService>
    {
        protected override async void OpenAddPage()
        {
            await Shell.Current.GoToAsync($"/{nameof(AddIncomePage)}");
        }
        protected override async Task OpenEditPage(IncomeDto dto)
        {
            if (dto == null) return;
            await Shell.Current.GoToAsync($"{nameof(EditIncomePage)}?itemId={dto.Id}");
        }
    }
}
