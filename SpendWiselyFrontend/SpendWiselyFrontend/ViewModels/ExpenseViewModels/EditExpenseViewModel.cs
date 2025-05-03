using SpendWiselyFrontend.Dtos;
using SpendWiselyFrontend.Services.Abstractions;
using SpendWiselyFrontend.ViewModels.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SpendWiselyFrontend.ViewModels.ExpenseViewModels
{
    public class EditExpenseViewModel : BaseSingleViewModel<ExpenseDto, IExpenseService>
    {
    }
}
