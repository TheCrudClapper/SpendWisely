using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
   
    public class Budget : BaseModel
    {
        public int AccountId { get; set; }
        [ForeignKey("AccountId")]
        public Account Account { get; set; } = null!;

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = null!;
        public decimal AmountLimit { get; set; }
        public string Name { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
       
        public string? EmojiUrl { get; set; }
    }
}
