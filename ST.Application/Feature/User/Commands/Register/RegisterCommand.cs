using ST.Application.Commons.Response;
using ST.Application.Wrappers;
using ST.Contracts.Authentication;

namespace ST.Application.Feature.User.Commands.Register
{
    public class RegisterCommand(AuthRequest request) : ICommand<Response>
    {
        public AuthRequest Request { get; set; } = request;
    }
}
