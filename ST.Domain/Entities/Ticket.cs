using ST.Domain.Commons.Primitives;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST.Domain.Entities
{
    public class Ticket : Entity
    {
        public string Name { get; set; }
        public string? Description { get; set; }

        [ForeignKey("Categories")]
        public int CategoryId { get; set; }

        public int CounterDrive { get; set; }
        public string ImgPath { get; set; }
        public decimal FinalDiscount { get; set; }
        public decimal FinalDiscountPercent { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal FinalPrice { get; set; }
        public virtual Category Category { get; set; }
    }
}