using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ST.Domain.Entities
{
    public class Account
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
        public string Salt { get; set; }
        public string? FullName { get; set; }
        public DateTime? DoB { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        [ForeignKey("Roles")]
        public int RoleId { get; set; }
        public virtual Role Roles { get; set; }
    }
}