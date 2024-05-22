using ST.Application.Wrappers;
using ST.Contracts.Authentication;
using ST.Doamin.Commons.Primitives;

namespace ST.Application.Feature.User.Command.Login
{
    public class LoginCommand(LoginRequest request) : ICommand<Response<AuthResponse>>
    {
        public LoginRequest Request { get; set; } = request;
    }
}