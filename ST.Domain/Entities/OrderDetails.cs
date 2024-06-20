using ST.Domain.Commons.Primitives;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST.Domain.Entities
{
    public class OrderDetails : Entity
    {
        [ForeignKey("Orders")]
        public Guid OrderId { get; set; }

        [ForeignKey("Tickets")]
        public Guid TicketId { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}