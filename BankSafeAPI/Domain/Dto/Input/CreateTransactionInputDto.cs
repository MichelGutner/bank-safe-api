using BankSafeAPI.Domain.Enums;

namespace BankSafeAPI.Domain.Dto.Input
{
    public class CreateTransactionInputDto : TransactionBaseInputDto
    {
        public decimal Amount { get; set; } = decimal.Zero;
        public string? Description { get; set; }
    }
}
