using AutoMapper;
using ST.Application.Wrappers;
using ST.Contracts.Ticket;
using ST.Domain.Entities;
using ST.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Application.Feature.Tickets.Commands.CreateTicketCommand
{
    public class CreateTicketCommandHandler : ICommandHandler<CreateTicketCommand, Result>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public CreateTicketCommandHandler(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }
        public async Task<Result> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<TicketRequest, Ticket>(request.Request);
            await _ticketRepository.CreateAsync(result);
            return Response.Success("Thêm vé thành công");
        }
    }
}
