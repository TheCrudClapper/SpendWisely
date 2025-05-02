using Microsoft.Extensions.DependencyInjection;
using SpendWiselyFrontend.ClientServices.Abstractions;
using SpendWiselyFrontend.Dtos;
using SpendWiselyFrontend.Services.Abstractions;
using SpendWiselyFrontend.ViewModels.Abstractions;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SpendWiselyFrontend.ViewModels.CategoriesViewModels
{
    public class EditCategoryViewModel : BaseSingleViewModel<CategoryDto, ICategoryService> { }
}
