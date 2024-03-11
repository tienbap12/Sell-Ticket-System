using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementSystem.Domain.Entities
{
    public class RefreshToken
    {
        public long Id { get; set; }
        public int UserId { get; set; } 
        [ForeignKey(nameof(UserId))]
        public Account Account { get; set; }
        public string Token { get; set; }
        public string JwtId { get; set; }
        public bool IsUsed { get; set; } 
        public bool IsRevoked { get; set; } 
        public DateTime AddedDate { get; set; }
        public DateTime ExpiryDate { get; set; } 
    }
}
