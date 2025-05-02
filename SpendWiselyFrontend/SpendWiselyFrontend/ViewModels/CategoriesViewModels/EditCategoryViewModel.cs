using Microsoft.Extensions.DependencyInjection;
using SpendWiselyFrontend.ClientServices.Abstractions;
using SpendWiselyFrontend.Dtos;
using SpendWiselyFrontend.Services.Abstractions;
using SpendWiselyFrontend.ViewModels.Abstractions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SpendWiselyFrontend.ViewModels.CategoriesViewModels
{
    public class EditCategoryViewModel : BaseSingleViewModel
    {
        private readonly ICategoryService _categoryService;
        public CategoryDto _category;
        public CategoryDto Category
        {
            get => _category;
            set => SetProperty(ref _category, value);

        }
        public EditCategoryViewModel()
        {
            _categoryService = App.ServiceProvider.GetService<ICategoryService>();
        }
        public async void LoadAccount(int id)
        {
            Category = await _categoryService.GetCategory(id);
        }
        protected override async Task Save()
        {
            await _categoryService.Edit(Category.Id, Category);
            await Shell.Current.GoToAsync("..");
        }
        protected override async Task Delete()
        {
            var confirmed = await Application.Current.MainPage.DisplayAlert(
            "Deleting Category",
            "Are you sure you want to delete category",
            "Yep",
            "Nah");

            if (!confirmed) return;

            await _categoryService.Delete(_category.Id);

            await Shell.Current.GoToAsync("..");
        }
    }
}
