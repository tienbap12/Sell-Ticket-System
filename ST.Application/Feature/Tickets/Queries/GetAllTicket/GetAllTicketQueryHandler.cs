using AutoMapper;
using ST.Application.Commons.Response;
using ST.Application.Wrappers;
using ST.Contracts.Ticket;
using ST.Domain.Repositories;

namespace ST.Application.Feature.Tickets.Queries.GetAllTicket
{
    public class GetAllTicketQueryHandler : IQueryHandler<GetAllTicketQuery, List<TicketResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ITicketRepository _ticketRepository;

        public GetAllTicketQueryHandler(ITicketRepository ticketRepository, IMapper mapper)
        {
            _mapper = mapper;
            _ticketRepository = ticketRepository;
        }

        public async Task<Response<List<TicketResponse>>> Handle(GetAllTicketQuery request, CancellationToken cancellationToken)
        {
            var tickets = await _ticketRepository.GetAllTicketWithCategory();
            if (tickets is null)
            {
                return Response<List<TicketResponse>>.Failure("Not found");
            }
            var Response = _mapper.Map<List<TicketResponse>>(tickets);
            return Response<List<TicketResponse>>.Success("Get data successfully!!!", Response.ToList());
        }
    }
}