using ST.Application.Tickets.DTOs;
using ST.Application.Wrappers;

namespace ST.Application.Tickets.Queries
{
    public class GetTicketByIdQuery(int id) : IRequestWrapper<TicketDto>
    {
        public int Id { get; set; } = id;
    }
}
