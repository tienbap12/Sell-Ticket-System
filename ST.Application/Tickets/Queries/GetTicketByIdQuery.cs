using SchoolManagementSystem.Application.Tickets.DTOs;
using SchoolManagementSystem.Application.Wrappers;
using SchoolManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Application.Tickets.Queries
{
    public class GetTicketByIdQuery(int id) : IRequestWrapper<TicketDto>
    {
        public int Id { get; set; } = id;
    }
}
