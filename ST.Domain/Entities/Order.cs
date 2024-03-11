using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
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
