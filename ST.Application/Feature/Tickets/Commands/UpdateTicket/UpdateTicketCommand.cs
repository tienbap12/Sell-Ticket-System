using ST.Application.Wrappers;
using ST.Contracts.Ticket;

namespace ST.Application.Feature.Tickets.Commands.UpdateTicket
{
    internal class UpdateTicketCommand(TicketRequest request, int id) : ICommand<Result>
    {
        public TicketRequest Request { get; set; } = request;
        public int Id { get; set; } = id;
    }
}
