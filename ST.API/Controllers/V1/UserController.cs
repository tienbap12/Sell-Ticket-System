using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ST.API.Contracts;
using ST.Application.Feature.User.Commands.Login;
using ST.Application.Feature.User.Commands.Register;
using ST.Contracts.Authentication;
using LoginRequest = Microsoft.AspNetCore.Identity.Data.LoginRequest;

namespace ST.API.Controllers.V1;

public class UserController : ApiController
{
    [HttpPost]
    [Route(ApiRoutesV1.Account.Login)]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var command = new LoginCommand(request);
        return Ok(await Mediator.Send(command));
    }
    
    [HttpPost]
    [Route(ApiRoutesV1.Account.Register)]
    public async Task<IActionResult> Register([FromBody] AuthRequest request)
    {
        var command = new RegisterCommand(request);
        return Ok(await Mediator.Send(command));
    }
}