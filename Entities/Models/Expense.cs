using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Expense : BaseModel
    {
        public string Name { get; set; } = null!;
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account Account { get; set; } = null!;

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = null!;
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }
        public string Description { get; set; } = null!;

    }
}
