namespace Services.Dtos
{
    public class ExpenseDto
    {
        public string Name { get; set; } = null!;
        public int AccountId { get; set; }
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; } = null!;

    }
}
