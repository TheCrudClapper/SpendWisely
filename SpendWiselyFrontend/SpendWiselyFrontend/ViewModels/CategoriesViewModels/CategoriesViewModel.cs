using SpendWiselyFrontend.Dtos;
using SpendWiselyFrontend.Services.Abstractions;
using SpendWiselyFrontend.ViewModels.Abstractions;
using SpendWiselyFrontend.Views.CategoryViews;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SpendWiselyFrontend.ViewModels.CategoriesViewModels
{
    public class CategoriesViewModel : BaseManyViewModel<CategoryDto, ICategoryService>
    {
        protected override void OpenAddPage()
        {
            Shell.Current.GoToAsync($"/{nameof(AddCategoryPage)}");
        }
        protected override async Task OpenEditPage(CategoryDto category)
        {
            if (category == null) return;
            await Shell.Current.GoToAsync($"{nameof(EditCategoryPage)}?accountId={category.Id}");
        }
    }
}
