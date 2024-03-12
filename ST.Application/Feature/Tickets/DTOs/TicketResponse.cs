using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ST.Application.Feature.Tickets.DTOs
{
    public class TicketResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public int CounterDrive { get; set; }
        public bool IsCombo { get; set; }
        public string Slug { get; set; }
        public string Resources { get; set; }
        public decimal? FinalDiscount { get; set; }
        public decimal? FinalDiscountPercent { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal FinalPrice { get; set; }
    }
}
