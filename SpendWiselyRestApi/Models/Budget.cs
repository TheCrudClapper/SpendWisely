﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Models
{
   
    public class Budget : BaseModel
    {
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; } = null!;
        [Column(TypeName = "decimal(10, 2)")]
        public decimal AmountLimit { get; set; }
        public string Name { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
       
        public string? EmojiUrl { get; set; }
        public ICollection<BudgetCategory> BudgetCategories { get; set; } = new List<BudgetCategory>();
    }
}
