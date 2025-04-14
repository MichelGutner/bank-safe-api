using BankSafeAPI.Domain.Enums;

namespace BankSafeAPI.Domain.Dto
{
    public class AccountDto
    {
        public int AccountId { get; set; }
        public required string AccountNumber { get; set; }
        public required string Agency { get; set; }
        public decimal Balance { get; set; }
        public string AccountType { get; set; }
    }
}