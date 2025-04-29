using System;
using System.Collections.Generic;
using System.Text;

namespace SpendWiselyFrontend.Dtos
{
    public class IncomeDto
    {
        public int UserId { get; set; }
        public int AccountId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public decimal Amount { get; set; }
    }
}
