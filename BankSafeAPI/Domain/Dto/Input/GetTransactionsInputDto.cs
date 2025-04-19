using BankSafeAPI.Domain.Enums;

namespace BankSafeAPI.Domain.Dto.Input
{
    public class GetTransactionsInputDto
    {
        public int? AccountId { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string? TransactionType { get; set; }
        public decimal? MinAmount { get; set; }
        public decimal? MaxAmount { get; set; }
    }
}
