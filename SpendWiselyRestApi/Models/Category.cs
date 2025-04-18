﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
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
        public ICollection<BudgetCategory> BudgetCategories { get; set; } = new List<BudgetCategory>();
    }
}
