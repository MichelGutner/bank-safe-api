using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BankSafeAPI.Domain.Enums;

namespace BankSafeAPI.Entities
{
    [Table("Accounts")]
    public class Account
    {
        [Key]
        public int AccountId { get; set; }
        public required string AccountNumber { get; set; }
        public required string Agency { get; set; }
        public required string AccountType { get; set; }
        public decimal Balance { get; set; }
        public string Status { get; set; } = AccountStatus.Active;

        [ForeignKey("UserId")]
        public int? UserId { get; set; }
    }
}