using ST.Application.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Application.Feature.Tickets.Commands.CreateTicketCommand
{
    public class CreateTicketCommandHandler : ICommandHandler<CreateTicketCommand, Response>
    {
        public Task<Response> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
