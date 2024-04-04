using ST.Application.Commons.Response;
using ST.Application.Wrappers;
using ST.Contracts.Ticket;

namespace ST.Application.Feature.Tickets.Commands.CreateTicketCommand
{
    public class CreateTicketCommand(TicketRequest request) : ICommand<Response>
    {
        public TicketRequest Request { get; set; } = request;
    }
}
