using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models.IdentityEntities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ICollection<UserCategory> UserCategories { get; set; } = new List<UserCategory>();
        public ICollection<Account> Accounts { get; set; } = new List<Account>();
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime? DateEdited { get; set; }
        public DateTime? DateDeleted { get; set; }
    }
}
