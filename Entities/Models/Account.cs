using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Account : BaseModel
    {
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;
        public string Name { get; set; } = null!;
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Balance { get; set; }
        public string? Description { get; set; }
        public string? EmojiUrl { get; set; }
        public ICollection<Expense> Expenses = new List<Expense>();
        public ICollection<Income> Incomes = new List<Income>();
        public ICollection<Budget> Budgets = new List<Budget>();
        public ICollection<RecurringExpense> RecurringExpenses = new List<RecurringExpense>();
    }
}
