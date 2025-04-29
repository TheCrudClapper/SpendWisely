namespace Entities.Models
{
    public enum CategoryFor
    {
        Expenses = 1,
        Incomes = 2,
    }
    public class Category : BaseModel
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public bool IsPredifined { get; set;  }
        public string? EmojiUrl { get; set; }

        public ICollection<UserCategory> UserCategories { get; set; } = new List<UserCategory>();
    }
}
