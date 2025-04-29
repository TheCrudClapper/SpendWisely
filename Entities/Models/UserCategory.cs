using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class UserCategory : BaseModel
    {
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = null!;
    }
}
