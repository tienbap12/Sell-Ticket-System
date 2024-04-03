using ST.Application.Wrappers;
using ST.Contracts.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Application.Feature.User.Commands.Login
{
    public class LoginCommand(LoginRequest request) : ICommand<Response<AuthResponse>>
    {
        public LoginRequest Request { get; set; } = request;
    }
}
