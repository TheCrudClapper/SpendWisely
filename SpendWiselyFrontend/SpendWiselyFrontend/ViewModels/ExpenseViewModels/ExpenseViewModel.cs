using SpendWiselyFrontend.Dtos;
using SpendWiselyFrontend.Services.Abstractions;
using SpendWiselyFrontend.ViewModels.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpendWiselyFrontend.ViewModels.ExpenseViewModels
{
    public class ExpenseViewModel : BaseSingleViewModel<CategoryDto, ICategoryService>
    {
    }
}
