using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ST.API.Contracts;
using ST.Application.Feature.Tickets.Commands.CreateTicketCommand;
using ST.Application.Feature.Tickets.Queries.GetAllTicket;
using ST.Application.Feature.Tickets.Queries.GetTicketById;
using ST.Contracts.Ticket;
using System.Threading.Tasks;

namespace ST.API.Controllers.V1
{
    [ApiController]
    public class TicketController : ApiController
    {
        [HttpGet(ApiRoutesV1.Ticket.GetAll)]
        public async Task<IActionResult> GetAllAsync()
        {
            var query = new GetAllTicketQuery();
            return Ok(await Mediator.Send(query));
        }
        [HttpGet(ApiRoutesV1.Ticket.GetById)]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var query = new GetTicketByIdQuery(id);
            return Ok(await Mediator.Send(query));
        }
        [HttpPost(ApiRoutesV1.Ticket.Create)]
        public async Task<IActionResult> CreateAsync([FromBody] TicketRequest request)
        {
            var command = new CreateTicketCommand(request);
            return Ok(await Mediator.Send(command));
        }
    }
}
