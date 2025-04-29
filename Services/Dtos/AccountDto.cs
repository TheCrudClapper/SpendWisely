using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Dtos
{
    public class AccountDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Balance { get; set; }
        public string? Description { get; set; }
        public string? EmojiUrl { get; set; }
    }
}
