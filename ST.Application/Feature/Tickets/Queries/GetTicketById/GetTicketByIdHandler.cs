using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ST.Application.Commons.Interfaces;
using ST.Application.Feature.Tickets.DTOs;
using ST.Application.Wrappers;

namespace ST.Application.Feature.Tickets.Queries.GetTicketById
{
    public class GetTicketByIdHandler : IRequestHandlerWrapper<GetTicketByIdQuery, TicketResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetTicketByIdHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Response<TicketResponse>> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
        {
            var ticket = await _context.Tickets.Include(c => c.Category).Where(t => t.Id == request.Id).SingleOrDefaultAsync(cancellationToken);
            if (ticket is null)
            {
                return Response.Fail<TicketResponse>($"khong tim thay ticket {request.Id}");
            }
            var result = _mapper.Map<TicketResponse>(ticket);
            return Response.Success(result, $"Lay du lieu thanh cong {request.Id}");
        }
    }
}
