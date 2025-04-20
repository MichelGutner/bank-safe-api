using System.ComponentModel.DataAnnotations;
using BankSafeAPI.Domain.Enums;

namespace BankSafeAPI.Domain.Dto.Input
{
    public class CreateTransactionInputDto
    {
        public decimal Amount { get; set; } = decimal.Zero;
        public string? Description { get; set; }

        [Required(ErrorMessage = "O número da conta e obrigatório.")]
        public required int AccountId { get; set; }

        [Required(ErrorMessage = "O tipo de transação e obrigatório.")]
        [RegularExpression(
            @"^(deposit|withdraw|transfer|payment)$",
            ErrorMessage = "O tipo de transação deve ser 'deposit' | 'withdraw' | 'transfer' | 'payment'."
        )]
        public required string TransactionType { get; set; }
    }
}
