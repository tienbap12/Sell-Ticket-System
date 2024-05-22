using ST.Application.Wrappers;
using ST.Contracts.Ticket;
using ST.Doamin.Commons.Primitives;

namespace ST.Application.Feature.Tickets.Command.CreateTicketCommand
{
    public class CreateTicketCommand(TicketRequest request) : ICommand<Response>
    {
        public TicketRequest Request { get; set; } = request;
    }
}