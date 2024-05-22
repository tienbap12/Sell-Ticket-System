using ST.Domain.Commons.Primitives;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST.Domain.Entities
{
    public class OrderDetails : Entity
    {
        [ForeignKey("Orders")]
        public int OrderId { get; set; }

        [ForeignKey("Tickets")]
        public int TicketId { get; set; }

        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}