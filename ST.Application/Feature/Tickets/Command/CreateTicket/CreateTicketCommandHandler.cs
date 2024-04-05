using AutoMapper;
using ST.Application.Commons.Response;
using ST.Application.Wrappers;
using ST.Contracts.Ticket;
using ST.Domain.Entities;
using ST.Domain.Repositories;

namespace ST.Application.Feature.Tickets.Command.CreateTicketCommand
{
    public class CreateTicketCommandHandler : ICommandHandler<CreateTicketCommand, Response>
    {
        private readonly ITicketRepository _ticketRepository;
        private readonly IMapper _mapper;

        public CreateTicketCommandHandler(ITicketRepository ticketRepository, IMapper mapper)
        {
            _ticketRepository = ticketRepository;
            _mapper = mapper;
        }
        public async Task<Response> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var result = _mapper.Map<TicketRequest, Ticket>(request.Request);
            try
            {
                await _ticketRepository.CreateAsync(result);
                return Response.CreateSuccessfully("Ticket");

            }
            catch (Exception)
            {
                return Response.CreateFailed("Ticket");
            }
        }
    }
}
