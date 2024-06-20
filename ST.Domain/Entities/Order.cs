using ST.Domain.Commons.Abstractions;
using ST.Domain.Commons.Primitives;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST.Domain.Entities
{
    public class Order : Entity, IAuditInfo
    {
        [ForeignKey("Accounts")]
        public Guid UserId { get; set; }

        public decimal TotalAmount { get; set; }
        public virtual Account Accounts { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? LastModifiedOn { get; set; }
        public virtual ICollection<OrderDetails> Details { get; set; }
    }
}