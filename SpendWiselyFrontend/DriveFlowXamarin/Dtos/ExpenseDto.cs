using System;
using System.Collections.Generic;
using System.Text;

namespace SpendWiselyFrontend.Dtos
{
    public class ExpenseDto
    {
        public int UserId;
        public int AccountId { get; set; }

        public string Name { get; set; }
        public int CategoryId { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
    }
}
