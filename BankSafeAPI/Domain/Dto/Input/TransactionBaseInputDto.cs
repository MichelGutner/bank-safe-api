using BankSafeAPI.Domain.Enums;

namespace BankSafeAPI.Domain.Dto.Input
{
    public class TransactionBaseInputDto
    {
        public int AccountId { get; set; }
        public EnumTransactionType? TransactionType { get; set; }
    }
}
