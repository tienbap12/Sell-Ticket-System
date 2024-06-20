using ST.Domain.Commons.Abstractions;
using ST.Domain.Commons.Primitives;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST.Domain.Entities
{
    public class Account : Entity, IAuditInfo
    {
        [StringLength(64)]
        public string Username { get; set; } = string.Empty;

        [StringLength(64)]
        public string Password { get; set; } = string.Empty;

        [StringLength(512)]
        public string Salt { get; set; } = string.Empty;

        [StringLength(128)]
        public string FullName { get; set; } = string.Empty;

        public DateTime? DoB { get; set; }

        [StringLength(11)]
        public string Phone { get; set; } = string.Empty;

        [StringLength(128)]
        public string Email { get; set; } = string.Empty;

        [ForeignKey("Roles")]
        public  Guid RoleId { get; set; }

        public virtual Role Roles { get; set; }
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime? LastModifiedOn { get; set; }
    }
}