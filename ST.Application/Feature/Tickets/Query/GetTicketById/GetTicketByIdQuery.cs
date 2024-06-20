using ST.Application.Wrappers;
using ST.Contracts.Ticket;

namespace ST.Application.Feature.Tickets.Query.GetTicketById
{
    public class GetTicketByIdQuery(Guid id) : IQuery<TicketResponse>
    {
        public Guid Id { get; set; } = id;
    }
}
