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
            SaveCommand = new Command(SaveChanges);
            ClearInputsCommand = new Command(ClearInputs);
        }
        protected virtual void SaveChanges()
        {

        }
        protected virtual void ClearInputs()
        {

        }
    }
}
