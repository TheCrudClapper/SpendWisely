using System.Threading.Tasks;
using Xamarin.Forms;

namespace SpendWiselyFrontend.ViewModels.Abstractions
{
    public class BaseSingleViewModel : BaseViewModel
    {
        public Command SaveCommand { get; set; }
        public Command UpdateCommand { get; set; }
        public Command DeleteCommand { get; set; }
        public Command ClearInputsCommand { get; set; }
        public BaseSingleViewModel()
        {

            SaveCommand = new Command(async () => await Save());
            DeleteCommand = new Command(async () => await Delete());
            UpdateCommand = new Command(async () => await Update());
            ClearInputsCommand = new Command(ClearInputs);
        }
        protected async virtual Task Delete() { }
        protected async virtual Task Save() { }
        protected async virtual Task Update() { }
        protected virtual void ClearInputs() { }
    }
}
