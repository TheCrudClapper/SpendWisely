using System;
using System.Collections.Generic;
using System.Text;

namespace SpendWiselyFrontend.Dtos
{
    public class AccountDto
    {
        public int Id { get; set; }
        public int UserId { get; set; } 
        public string Name { get; set; }
        public decimal Balance { get; set; } 
        public string Description { get; set; }
        public string EmojiUrl { get; set; } 
    }
}
