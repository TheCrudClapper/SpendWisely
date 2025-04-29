namespace Entities.Models
{
    //DONE
    public class User : BaseModel
    {
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;
        public ICollection<UserCategory> UserCategories { get; set; } = new List<UserCategory>();
        public ICollection<Account> Accounts { get; set; } = new List<Account>();
    }
}
