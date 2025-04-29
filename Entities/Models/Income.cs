using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class Income : BaseModel
    {
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account Account { get; set; } = null!;
        public string? EmojiUrl { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        [Column(TypeName = "decimal(10, 2)")]
        public decimal Amount { get; set; }

    }
}
