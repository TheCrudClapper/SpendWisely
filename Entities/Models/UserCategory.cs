using Entities.Models.IdentityEntities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Models
{
    public class UserCategory : BaseModel
    {
        public Guid UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; } = null!;

        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; } = null!;
    }
}
