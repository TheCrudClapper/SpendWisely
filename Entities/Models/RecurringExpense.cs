using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public enum RepeatUnit
    {
        Days = 1,
        Weeks = 2,
        Months = 3,
        Years = 4,
    }
    public class RecurringExpense : BaseModel
    {
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account Account { get; set; } = null!;

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = null!;
        public int RepeatInterval { get; set; }
        public RepeatUnit RepeatUnit { get; set; }
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }

        public DateTime StartDate { get; set; }
        public string Description { get; set; } = null!;
    }
}
