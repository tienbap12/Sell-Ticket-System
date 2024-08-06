using ST.Application.Wrappers;
using ST.Contracts.Authentication;
using ST.Doamin.Commons.Primitives;
using LoginRequest = Microsoft.AspNetCore.Identity.Data.LoginRequest;

namespace ST.Application.Feature.User.Commands.Login;

public class LoginCommand(LoginRequest request) : ICommand<Response<AuthResponse>>{
    public string Email { get; set; } = request.Email;
    public string Password { get; set; } = request.Password;
}