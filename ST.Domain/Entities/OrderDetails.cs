using SchoolManagementSystem.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public class OrderDetails
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Orders")]
        public Guid OrderId { get; set; }
        [ForeignKey("Tickets")]
        public int TicketId { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual Ticket Ticket { get; set; }

    }
}
