using AutoMapper;
using ST.Application.Wrappers;
using ST.Contracts.Ticket;
using ST.Domain.Repositories;

namespace ST.Application.Feature.Tickets.Queries.GetAllTicket
{
    public class GetAllTicketQueryHandler : IQueryHandler<GetAllTicketQuery, IList<TicketResponse>>
    {
        private readonly IMapper _mapper;
        private readonly ITicketRepository _ticketRepository;

        public GetAllTicketQueryHandler(ITicketRepository ticketRepository, IMapper mapper)
        {
            _mapper = mapper;
            _ticketRepository = ticketRepository;
        }

        public async Task<Response<IList<TicketResponse>>> Handle(GetAllTicketQuery request, CancellationToken cancellationToken)
        {
            var tickets = await _ticketRepository.GetAllTicketWithCategory();
            if (tickets is null)
            {
                return Response.Fail<IList<TicketResponse>>("khong lay duoc du lieu");
            }
            //Do tickets là 1 list nên muốn map thì phải dùng IEnumerable
            /*var result = _mapper.Map<TicketResponse>(tickets);*/
            var result = _mapper.Map<IEnumerable<TicketResponse>>(tickets);
            return Response.Success<IList<TicketResponse>>(result.ToList(), "lay du lieu thanh cong");
        }
    }
}