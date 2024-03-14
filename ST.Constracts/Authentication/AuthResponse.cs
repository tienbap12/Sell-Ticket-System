using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Contracts.Authentication
{
    public class AuthResponse
    {
        public string token { get; set; } = null!;
        public string Role { get; set; }
    }
}
