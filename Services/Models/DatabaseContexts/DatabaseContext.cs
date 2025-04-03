using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Services.Models;
namespace Services.Models.DatabaseContexts
{
    public class DatabaseContext : DbContext
    {
        public DbSet<User> Users { get; set; }

    }
}
