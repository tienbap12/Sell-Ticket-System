using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Contracts.Authentication
{
    public class LoginRequest
    {
        public string userName { get; set; }
        public string Password { get; set; }
    }
}
