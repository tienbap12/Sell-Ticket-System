using ST.Application.Wrappers;
using ST.Contracts.Ticket;

namespace ST.Application.Feature.Tickets.Query.GetTicketById
{
    public class GetTicketByIdQuery(int id) : IQuery<TicketResponse>
    {
        public int Id { get; set; } = id;
    }
}
