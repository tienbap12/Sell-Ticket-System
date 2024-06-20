using ST.Domain.Commons.Abstractions;
using ST.Domain.Commons.Primitives;
using System;

namespace ST.Domain.Entities
{
    public class Role : Entity, IAuditInfo
    {
        public string Name { get; set; }
        public string Status { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? LastModifiedOn { get; set; }
    }
}