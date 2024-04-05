using ST.Application.Commons.Response;
using ST.Application.Wrappers;
using ST.Contracts.Authentication;

namespace ST.Application.Feature.User.Command.Login
{
    public class LoginCommand(LoginRequest request) : ICommand<Response<AuthResponse>>
    {
        public LoginRequest Request { get; set; } = request;
    }
}
