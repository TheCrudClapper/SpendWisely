using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Dtos
{
    public class AuthResponseDto
    {
        public bool Success { get; set; }
        public string? Token { get; set; }
        public List<string> Errors { get; set; } = new();
    }
}
