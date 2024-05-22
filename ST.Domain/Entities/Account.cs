using ST.Domain.Commons.Primitives;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST.Domain.Entities
{
    public class Account : Entity
    {
        [StringLength(64)]
        public string Username { get; set; } = string.Empty;

        [StringLength(64)]
        public string Password { get; set; } = string.Empty;

        [StringLength(512)]
        public string Salt { get; set; } = string.Empty;

        [StringLength(128)]
        public string? FullName { get; set; }

        public DateTime? DoB { get; set; }

        [StringLength(11)]
        public string? Phone { get; set; }

        [StringLength(128)]
        public string? Email { get; set; }

        [ForeignKey("Roles")]
        public int RoleId { get; set; }

        public virtual Role Roles { get; set; }
    }
}