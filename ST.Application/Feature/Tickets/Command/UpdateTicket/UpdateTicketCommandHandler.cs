using AutoMapper;
using ST.Application.Wrappers;
using ST.Contracts.Ticket;
using ST.Doamin.Commons.Primitives;
using ST.Domain.Entities;
using ST.Domain.Repositories;

namespace ST.Application.Feature.Tickets.Command.UpdateTicket
{
    internal class UpdateTicketCommandHandler(ITicketRepository ticketRepository, IMapper mapper) : ICommandHandler<UpdateTicketCommand, Response>
    {
        public async Task<Response> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticketExist = await ticketRepository.GetByIdAsync(request.Id);
            if (ticketExist == null)
            {
                return Response.NotFound("Ticket", request.Id);
            }

            var updateTicket = mapper.Map<TicketRequest, Ticket>(request.Request, ticketExist);

            try
            {
                await ticketRepository.UpdateAsync(updateTicket);
                return Response.UpdateSuccessfully("Ticket");
            }
            catch (Exception)
            {
                return Response.UpdateFailed("Ticket");
            }
        }
    }
}