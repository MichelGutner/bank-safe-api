using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using BankSafeAPI.Domain.Enums;

namespace BankSafeAPI.Entities
{
    public class Transactions
    {
        [Key]
        public int TransactionId { get; set; }
        public required EnumTransactions TransactionType { get; set; }
        public required decimal Amount { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }

        [ForeignKey("AccountId")]
        public int? Account { get; set; }
    }
}
