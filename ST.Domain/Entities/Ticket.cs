using ST.Domain.Commons.Abstractions;
using ST.Domain.Commons.Primitives;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ST.Domain.Entities
{
    public class Ticket : Entity, IAuditInfo
    {
        public string Name { get; set; }
        [StringLength(256)]
        public string Description { get; set; } = string.Empty;
        [ForeignKey(nameof(Category))]
        public  Guid CategoryId { get; set; }
        [StringLength(128)]
        public string ImgPath { get; set; }
        public decimal FinalDiscount { get; set; }
        public decimal FinalDiscountPercent { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal FinalPrice { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? LastModifiedOn { get; set; }
        public virtual Category Categories { get; set; }
    }
}