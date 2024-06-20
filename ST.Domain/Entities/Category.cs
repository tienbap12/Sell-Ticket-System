using ST.Domain.Commons.Abstractions;
using ST.Domain.Commons.Primitives;
using System;
using System.ComponentModel.DataAnnotations;

namespace ST.Domain.Entities
{
    public class Category : Entity, IAuditInfo
    {
        [StringLength(128)]
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public  Guid Status { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? LastModifiedOn { get; set; }
    }
}