using Microsoft.Extensions.DependencyInjection;
using SpendWiselyFrontend.Dtos;
using SpendWiselyFrontend.Services.Abstractions;
using SpendWiselyFrontend.ViewModels.Abstractions;
using SpendWiselyFrontend.Views.AccountViews;
using SpendWiselyFrontend.Views.CategoryViews;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SpendWiselyFrontend.ViewModels.CategoriesViewModels
{
    public class CategoriesViewModel : BaseManyViewModel<CategoryDto>
    {
        private readonly ICategoryService _categoryService;
        public Command  OpenAddCategoryPageCommand { get; set; }
        public Command OpenEditCategoryPageCommand { get; set; }
        public CategoriesViewModel()
        {
            OpenAddCategoryPageCommand = new Command( async () => await OpenAddCategoryPage() );
            OpenEditCategoryPageCommand = new Command<CategoryDto>(async (category) => await OpenEditCategoryPage(category));
            _categoryService = App.ServiceProvider.GetService<ICategoryService>();
        }
        private async Task OpenAddCategoryPage()
        {
            await Shell.Current.GoToAsync($"/{nameof(AddCategoryPage)}");
        }
        private async Task OpenEditCategoryPage(CategoryDto category)
        {
            if (category == null) return;
            await Shell.Current.GoToAsync($"{nameof(EditCategoryPage)}?accountId={category.Id}");
        }
        public override CategoryDto SelectedItem
        {
            get => base.SelectedItem;
            set
            {
                if (value != null)
                {
                    base.SelectedItem = value;

                    OpenEditCategoryPageCommand.Execute(value);

                    base.SelectedItem = null;
                    OnPropertyChanged(nameof(SelectedItem));
                }
            }
        }
        public async override Task LoadItemsAsync()
        {
            IsBusy = true;
            try
            {
                var categories = await _categoryService.GetCategories();
                Items.Clear();
                foreach (var category in categories)
                {
                    Items.Add(category);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to fetch acoounts");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
