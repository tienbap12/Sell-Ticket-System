using ST.Application.Wrappers;
using ST.Contracts.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Application.Feature.User.Commands.Login
{
    public class LoginCommand(string username, string password) : ICommand<Response<AuthResponse>>
    {
        public string Username { get; set; } = username;
        public string Password { get; set; } = password;
    }
}
