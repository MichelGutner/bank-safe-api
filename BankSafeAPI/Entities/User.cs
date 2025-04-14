using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BankSafeAPI.Entities
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserId { get; set; }
        public required string Username { get; set; }
        public required string Password { get; set; }
        public required string CPF { get; set; }
        public DateTime? CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? UpdatedAt { get; set; } = DateTime.UtcNow;
        public required string Email { get; set; }
        public virtual ICollection<Account> Accounts { get; set; } = [];
    }
}
