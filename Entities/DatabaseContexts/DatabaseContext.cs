using Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace Entities.DatabaseContexts
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<UserCategory> UserCategories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<RecurringExpense> RecurringExpenses { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

    }
}

