using AutoMapper;
using MediatR;
using ST.Application.Commons.Response;
using ST.Application.Wrappers;
using ST.Contracts.Ticket;
using ST.Domain.Repositories;

namespace ST.Application.Feature.Tickets.Queries.GetTicketById
{
    public class GetTicketByIdHandler : IQueryHandler<GetTicketByIdQuery, TicketResponse>
    {
        private readonly IMapper _mapper;
        private readonly ITicketRepository _ticketRepository;

        public GetTicketByIdHandler(ITicketRepository ticketRepository, IMapper mapper)
        {
            _mapper = mapper;
            _ticketRepository = ticketRepository;
        }

        public async Task<Response<TicketResponse>> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
        {
            var ticket = await _ticketRepository.GetTicketByIdWCate(request.Id);
            if (ticket is null)
            {
                return Response<TicketResponse>.NotFound("Ticket", request.Id);
            }
            var Response = _mapper.Map<TicketResponse>(ticket);
            return Response<TicketResponse>.Success($"Successfully retrieved ticket with Id {request.Id}", Response);
        }

    }
}
