using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    //DONE
    public class User : BaseModel
    {
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;

        public ICollection<UserCategory> UserCategories { get; set; } = new List<UserCategory>();
        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
        public ICollection<RecurringExpense> RecurringExpenses { get; set; } = new List<RecurringExpense>();
        public ICollection<Account> Accounts { get; set; } = new List<Account>();
        public ICollection<Income> Incomes { get; set; } = new List<Income>();

        public ICollection<Budget> Budgets { get; set; } = new List<Budget>();
        public ICollection<Report> Raports { get; set; } = new List<Report>();
    }
}
