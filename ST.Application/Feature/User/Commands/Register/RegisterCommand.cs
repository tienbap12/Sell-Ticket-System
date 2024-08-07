using ST.Application.Wrappers;
using ST.Contracts.Authentication;
using ST.Doamin.Commons.Primitives;

namespace ST.Application.Feature.User.Commands.Register;

public class RegisterCommand(AuthRequest request) : ICommand<Response>
{
    public AuthRequest Request { get; set; } = request;
}