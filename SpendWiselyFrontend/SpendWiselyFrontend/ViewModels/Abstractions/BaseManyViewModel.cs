using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SpendWiselyFrontend.ViewModels.Abstractions
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="Model">Can be a class or dto</typeparam>
    public class BaseManyViewModel<Model> : BaseViewModel
    {
        private Model _selectedItem;
        public ObservableCollection<Model> Items { get; set; }
        public Command EditCommand { get; set; }
        public Command LoadItemsCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public Model SelectedItem
        {
            get => _selectedItem;
            set
            {
                SetProperty(ref _selectedItem, value);
            }
        }
        public BaseManyViewModel()
        {
            EditCommand = new Command(Edit);
            DeleteCommand = new Command(Delete);
            LoadItemsCommand = new Command(async () => await LoadItemsAsync());
            Items = new ObservableCollection<Model>();
        }
        protected virtual void Edit()
        {

        }
        protected virtual void Delete()
        {

        }
        public virtual async Task LoadItemsAsync()
        {

        }

    }
}
