using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BankSafeAPI.Domain.Enums;

namespace BankSafeAPI.Entities
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public required string TransactionType { get; set; }
        public required decimal Amount { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("AccountId")]
        public int? AccountId { get; set; }
    }
}
