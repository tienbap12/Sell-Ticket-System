using ST.Application.Feature.Tickets.DTOs;
using ST.Application.Wrappers;

namespace ST.Application.Feature.Tickets.Queries.GetTicketById
{
    public class GetTicketByIdQuery(int id) : IRequestWrapper<TicketResponse>
    {
        public int Id { get; set; } = id;
    }
}
