using Entities.Models;
using Entities.Models.IdentityEntities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Entities.DatabaseContexts
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser, ApplicationRole, Guid>
    {
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

