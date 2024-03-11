using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST.Domain.Entities
{
    public class Order
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Accounts")]
        public int UserId { get; set; }
        public decimal TotalAmount { get; set; }
        public virtual Account Accounts { get; set; }
        public virtual ICollection<OrderDetails> Details { get; set; }

    }
}
