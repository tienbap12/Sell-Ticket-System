using Microsoft.AspNetCore.Mvc;
using ST.API.Contracts;
using ST.Application.Feature.User.Command.Login;
using ST.Application.Feature.User.Command.Register;
using ST.Contracts.Authentication;
using System.Threading.Tasks;

namespace ST.API.Controllers.V1
{
    [ApiController]
    public class AccountController : ApiController
    {
        [HttpPost(ApiRoutesV1.Account.Login)]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var command = new LoginCommand(request);
            return Ok(await Mediator.Send(command));
        }

        [HttpPost(ApiRoutesV1.Account.Register)]
        public async Task<IActionResult> Register([FromBody] AuthRequest request)
        {
            var command = new RegisterCommand(request);
            return Ok(await Mediator.Send(command));
        }
    }
}
