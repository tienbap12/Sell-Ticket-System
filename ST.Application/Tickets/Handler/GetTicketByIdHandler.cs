using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ST.Application.Commons.Interfaces;
using ST.Application.Tickets.DTOs;
using ST.Application.Tickets.Queries;
using ST.Application.Wrappers;

namespace ST.Application.Tickets.Handler
{
    public class GetTicketByIdHandler : IRequestHandlerWrapper<GetTicketByIdQuery, TicketDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTicketByIdHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response<TicketDto>> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
        {
            var ticket = await _context.Tickets.Where(t => t.Id == request.Id).AsNoTracking().SingleOrDefaultAsync(cancellationToken);
            if (ticket is null)
            {
                return Response.Fail<TicketDto>($"khong tim thay ticket {request.Id}");
            }
            var result = _mapper.Map<TicketDto>(ticket);
            return Response.Success<TicketDto>(result, $"tim thay san pham voi id {request.Id}");
        }
    }
}
