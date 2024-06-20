using ST.Application.Wrappers;
using ST.Contracts.Ticket;
using ST.Doamin.Commons.Primitives;

namespace ST.Application.Feature.Tickets.Command.UpdateTicket
{
    internal class UpdateTicketCommand(TicketRequest request, Guid id) : ICommand<Response>
    {
        public TicketRequest Request { get; set; } = request;
        public Guid Id { get; set; } = id;
    }
}