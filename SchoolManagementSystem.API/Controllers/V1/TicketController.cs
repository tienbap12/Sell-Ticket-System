using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolManagementSystem.API.Contracts;
using SchoolManagementSystem.Application.Tickets.Queries;
using System.Threading.Tasks;

namespace SchoolManagementSystem.API.Controllers.V1
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
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var query = new GetTicketByIdQuery(id);
            return Ok(await Mediator.Send(query));
        }
    }
}
