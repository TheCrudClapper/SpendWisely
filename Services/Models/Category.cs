using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
    public class Category : BaseModel
    {
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        public ICollection<UserCategory> UserCategories { get; set; } = new List<UserCategory>();
    }
}
