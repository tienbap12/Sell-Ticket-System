using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ST.Application.Commons.Interfaces;
using ST.Application.Feature.Tickets.DTOs;
using ST.Application.Wrappers;
using ST.Domain.Entities;

namespace ST.Application.Feature.Tickets.Queries.GetAllTicket
{
    public class GetAllTicketQueryHandler : IRequestHandlerWrapper<GetAllTicketQuery, IList<TicketResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllTicketQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<IList<TicketResponse>>> Handle(GetAllTicketQuery request, CancellationToken cancellationToken)
        {
            var tickets = await _context.Tickets.Include(c => c.Category).AsNoTracking().ToListAsync(cancellationToken);
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