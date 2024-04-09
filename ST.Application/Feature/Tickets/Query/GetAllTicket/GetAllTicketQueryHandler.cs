using AutoMapper;
using ST.Application.Commons.Response;
using ST.Application.Wrappers;
using ST.Contracts.Ticket;
using ST.Domain.Repositories;

namespace ST.Application.Feature.Tickets.Query.GetAllTicket
{
    public class GetAllTicketQueryHandler(ITicketRepository ticketRepository, IMapper mapper) : IQueryHandler<GetAllTicketQuery, List<TicketResponse>>
    {
        public async Task<Response<List<TicketResponse>>> Handle(GetAllTicketQuery request, CancellationToken cancellationToken)
        {
            var tickets = await ticketRepository.GetAllTicketWithCategory();
            if (tickets is null)
            {
                return Response<List<TicketResponse>>.Failure("Not found");
            }
            var Response = mapper.Map<List<TicketResponse>>(tickets);
            return Response<List<TicketResponse>>.Success("Get data successfully!!!", Response.ToList());
        }
    }
}