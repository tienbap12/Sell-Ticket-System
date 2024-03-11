using ST.Application.Wrappers;
using ST.Domain.Entities;

namespace ST.Application.Tickets.Queries
{
    public class GetAllTicketQuery : IRequestWrapper<IList<Ticket>>
    {
    }
}
