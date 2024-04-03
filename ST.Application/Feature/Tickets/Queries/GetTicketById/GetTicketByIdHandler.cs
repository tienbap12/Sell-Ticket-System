using AutoMapper;
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
                return Response.Fail<TicketResponse>($"khong tim thay ticket {request.Id}");
            }
            var result = _mapper.Map<TicketResponse>(ticket);
            return Response.Success(result, $"Lay du lieu thanh cong {request.Id}");
        }
    }
}
