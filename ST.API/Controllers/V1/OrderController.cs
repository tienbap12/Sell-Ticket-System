using Microsoft.AspNetCore.Mvc;
using ST.API.Contracts;
using ST.Application.Feature.Orders.Command;
using ST.Application.Feature.Orders.Query;
using ST.Application.Feature.Orders.Query.GetOrderDetail;
using ST.Constracts.Order;
using System;
using System.Threading.Tasks;

namespace ST.API.Controllers.V1
{
    [ApiController]
    public class OrderController : ApiController
    {
        [HttpPost(ApiRoutesV1.Order.Create)]
        public async Task<IActionResult> CreateOrder([FromBody] OrderRequest request)
        {
            var command = new CreateOrderCommand(request);
            var result = await Mediator.Send(command);
            return Ok(result);
        }
        [HttpGet(ApiRoutesV1.Order.GetAll)]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllOrderQuery();
            var result = await Mediator.Send(query);
            return Ok(result);
        }
        [HttpGet(ApiRoutesV1.Order.GetDetail)]
        public async Task<IActionResult> GetDetailAsync(Guid id)
        {
            var query = new GetOrderDetailQuery(id);
            var result = await Mediator.Send(query);
            return Ok(result);
        }
    }
}