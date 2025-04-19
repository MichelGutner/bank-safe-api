using BankSafeAPI.Domain.Enums;

namespace BankSafeAPI.Domain.Dto.Output
{
    public class TransactionOutputDto
    {
        public int TransactionId { get; set; }
        public required string TransactionType { get; set; }
        public required decimal Amount { get; set; }
        public string? Description { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
