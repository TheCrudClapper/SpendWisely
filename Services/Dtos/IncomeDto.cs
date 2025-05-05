namespace Services.Dtos
{
    public class IncomeDto
    {
        public int Id { get; set; }
        public int AccountId { get; set; }
        public string? EmojiUrl { get; set; }
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Amount { get; set; }

    }
}
