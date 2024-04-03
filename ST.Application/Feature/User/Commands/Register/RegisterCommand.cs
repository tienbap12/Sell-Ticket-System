using ST.Application.Wrappers;
using ST.Contracts.Authentication;

namespace ST.Application.Feature.User.Commands.Register
{
    public class RegisterCommand(AuthRequest request) : ICommand<Result>
    {
        public AuthRequest Request { get; set; } = request;
    }
}
