using Microsoft.AspNetCore.Mvc;
using ST.Application.Feature.Orders.Commands;
using ST.Constracts.Order;
using System.Threading.Tasks;

namespace ST.API.Controllers.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrderController : ApiController
    {
        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequest request)
        {
            var command = new CreateOrderCommand(request);
            var result = await Mediator.Send(command);
            return Ok(result);
        }
    }
}