using System.ComponentModel.DataAnnotations;

namespace SpendWiselyFrontend.Dtos
{
    public class IncomeDto
    {
        public int Id { get; set; }
        [Required]
        public int AccountId { get; set; }
        public string EmojiUrl { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public decimal Amount { get; set; }

    }
}
