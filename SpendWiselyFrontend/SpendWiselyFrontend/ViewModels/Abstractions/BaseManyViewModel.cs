using Microsoft.Extensions.DependencyInjection;
using SpendWiselyFrontend.Services.Abstractions;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SpendWiselyFrontend.ViewModels.Abstractions
{
    /// <summary>
    /// Abstract class that handles collection of items, allows for taping onto item to see it's details
    /// </summary>
    /// <typeparam name="Dto">Dto class for db model</typeparam>
    /// <typeparam name="ApiClientService">Refit Http Client used for sending and recieving http requests / responses</typeparam>
    public class BaseManyViewModel<Dto, ApiClientService> : BaseViewModel
        where ApiClientService : ICrudApiService<Dto>
    {
        private readonly ApiClientService _apiClientService;

        private Dto _selectedItem;
        public ObservableCollection<Dto> Items { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Command AddItemCommand { get; set; }
        public Command OpenEditPageCommand { get; set; }
        public virtual Dto SelectedItem
        {
            get => _selectedItem;
            set
            {
                if (value != null)
                {
                    _selectedItem = value;

                    OpenEditPageCommand.Execute(value);

                    _selectedItem = default;
                    OnPropertyChanged(nameof(SelectedItem));
                }
                
            }
        }
        public BaseManyViewModel()
        {
            _apiClientService = App.ServiceProvider.GetService<ApiClientService>();
            AddItemCommand = new Command(OpenAddPage);
            LoadItemsCommand = new Command(async () => await LoadItemsAsync());
            OpenEditPageCommand = new Command(async () => await OpenEditPage(SelectedItem));
            Items = new ObservableCollection<Dto>();
        }
        protected virtual async Task OpenEditPage(Dto dto) { }
        protected virtual void OpenAddPage() { }
        public virtual async Task LoadItemsAsync()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                var items = await _apiClientService.GetAll();

                foreach (var item in items)
                {
                    Items.Add(item);
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
