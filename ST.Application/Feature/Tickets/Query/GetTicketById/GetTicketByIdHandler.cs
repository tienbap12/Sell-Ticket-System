using AutoMapper;
using ST.Application.Wrappers;
using ST.Contracts.Ticket;
using ST.Doamin.Commons.Primitives;
using ST.Domain.Repositories;

namespace ST.Application.Feature.Tickets.Query.GetTicketById
{
    public class GetTicketByIdHandler(ITicketRepository ticketRepository, IMapper mapper) : IQueryHandler<GetTicketByIdQuery, TicketResponse>
    {
        public async Task<Response<TicketResponse>> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
        {
            var ticket = await ticketRepository.GetTicketByIdWCate(request.Id);
            if (ticket is null)
            {
                return Response<TicketResponse>.NotFound("Ticket", request.Id);
            }
            var Response = mapper.Map<TicketResponse>(ticket);
            return Response<TicketResponse>.Success($"Successfully retrieved ticket with Id {request.Id}", Response);
        }
    }
}