using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        [ForeignKey("Categories")]
        public int CategoryId { get; set; }
        public int CounterDrive { get; set; }
        public bool IsCombo { get; set; }
        public string Slug { get; set; }
        public string Resources { get; set; }
        public decimal FinalDiscount { get; set; }
        public decimal FinalDiscountPercent { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal FinalPrice { get; set; }
        public virtual Category Category { get; set; }
    }
}
