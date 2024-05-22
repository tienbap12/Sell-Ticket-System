using AutoMapper;
using ST.Application.Wrappers;
using ST.Contracts.Ticket;
using ST.Doamin.Commons.Primitives;
using ST.Domain.Entities;
using ST.Domain.Repositories;

namespace ST.Application.Feature.Tickets.Command.CreateTicketCommand
{
    public class CreateTicketCommandHandler(ITicketRepository ticketRepository, IMapper mapper) : ICommandHandler<CreateTicketCommand, Response>
    {
        public async Task<Response> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var result = mapper.Map<TicketRequest, Ticket>(request.Request);
            try
            {
                await ticketRepository.CreateAsync(result);
                return Response.CreateSuccessfully("Ticket");
            }
            catch (Exception)
            {
                return Response.CreateFailed("Ticket");
            }
        }
    }
}