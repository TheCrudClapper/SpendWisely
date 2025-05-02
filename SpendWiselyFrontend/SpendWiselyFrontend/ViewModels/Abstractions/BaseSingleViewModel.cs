using Microsoft.Extensions.DependencyInjection;
using SpendWiselyFrontend.Services.Abstractions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SpendWiselyFrontend.ViewModels.Abstractions
{
    /// <summary>
    /// Abstract class that handles singular item view, handles edit and adding view, allows also for deleting
    /// </summary>
    /// <typeparam name="Dto">Dto class for db model</typeparam>
    /// <typeparam name="ApiClientService">Refit Http Client used for sending and recieving http requests / responses</typeparam>
    public class BaseSingleViewModel<Dto, ApiClientService> : BaseViewModel
         where ApiClientService : ICrudApiService<Dto>
    {
        private readonly ApiClientService _apiClientService;
        public Dto _item;
        public int _itemId;
        public Dto Item
        {
            get => _item;
            set => SetProperty(ref _item, value);
        }
        public int ItemId
        {
            get => _itemId;
            set => SetProperty(ref _itemId, value);
        }

        public Command SaveCommand { get; set; }
        public Command UpdateCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public Command ClearInputsCommand { get; set; }
        public BaseSingleViewModel()
        {
            _apiClientService = App.ServiceProvider.GetService<ApiClientService>();
            SaveCommand = new Command(async () => await Save());
            DeleteCommand = new Command(async () => await Delete());
            UpdateCommand = new Command(async () => await Update());
            ClearInputsCommand = new Command(ClearInputs);
        }

        public async void LoadItem(int id)
        {
            Item = await _apiClientService.GetById(id);
            ItemId = id;
            OnPropertyChanged(nameof(Item));
        }

        protected async virtual Task Delete()
        {
            var confirmed = await Application.Current.MainPage.DisplayAlert(
            "Deleting Account",
            "Are you sure you want to delete account",
            "Yes",
            "No");

            if (!confirmed) return;

            await _apiClientService.Delete(ItemId);
            await Shell.Current.GoToAsync("..");
        }
        /// <summary>
        /// This class needs to be overridden by dev to include all dto field mappings
        /// </summary>
        /// <returns></returns>
        protected async virtual Task Save() { }
        protected async virtual Task Update()
        {
            await _apiClientService.Edit(ItemId, Item);
            await Shell.Current.GoToAsync("..");
        }
        protected virtual void ClearInputs() { }
    }
}
