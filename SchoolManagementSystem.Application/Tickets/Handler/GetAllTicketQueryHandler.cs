using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Application.Commons.Interfaces;
using SchoolManagementSystem.Application.Tickets.Queries;
using SchoolManagementSystem.Application.Wrappers;
using SchoolManagementSystem.Domain.Entities;

namespace SchoolManagementSystem.Application.Tickets.Handler
{
    public class GetAllTicketQueryHandler : IRequestHandlerWrapper<GetAllTicketQuery, IList<Ticket>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllTicketQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Response<IList<Ticket>>> Handle(GetAllTicketQuery request, CancellationToken cancellationToken)
        {
            var tickets = await _context.Tickets.AsNoTracking().ToListAsync(cancellationToken);
            if (tickets is null)
            {
                return Response.Fail<IList<Ticket>>("khong lay duoc du lieu");
            }
            /*var result = _mapper.Map<Ticket>(tickets);*/
            return Response.Success<IList<Ticket>>(tickets, "lay du lieu thanh cong");
        }
    }
}
