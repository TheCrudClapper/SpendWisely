using Microsoft.Extensions.DependencyInjection;
using SpendWiselyFrontend.ClientServices.Abstractions;
using SpendWiselyFrontend.Dtos;
using SpendWiselyFrontend.Services.Abstractions;
using SpendWiselyFrontend.ViewModels.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SpendWiselyFrontend.ViewModels.CategoriesViewModels
{
    public class AddCategoryViewModel : BaseSingleViewModel
    {
        private readonly ICategoryService _categoryService;
        public AddCategoryViewModel()
        {
            _categoryService = App.ServiceProvider.GetService<ICategoryService>();
        }
        #region Fields
            private string name;
            private string emoji;
            private string description;
        #endregion
        #region Props
        public string Name
        {
            get => name;
            set => SetProperty(ref name, value);
        }

        public string Emoji
        {
            get => emoji;
            set => SetProperty(ref emoji, value);
        }

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        #endregion

        protected override async Task Save()
        {
            if (IsBusy)
                return;

            IsBusy = true;

            var category = new CategoryDto
            {
                Name = Name,
                Description = Description,
                EmojiUrl = Emoji
            };

            try
            {
                await _categoryService.AddCategory(category);
                await AppShell.Current.DisplayAlert("Success", "Account Added!", "OK");
                await Shell.Current.GoToAsync("..");
            }
            catch (System.Exception ex)
            {
                await AppShell.Current.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        protected override void ClearInputs()
        {
            Name = string.Empty;
            Emoji = string.Empty;
            Description = string.Empty;
        }
    }
}

