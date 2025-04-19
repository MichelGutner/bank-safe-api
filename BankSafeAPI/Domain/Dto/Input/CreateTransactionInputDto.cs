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

        [Required(ErrorMessage = "O tipo de conta e obrigatório.")]
        [EnumDataType(typeof(EnumTransactionType))]
        public required string TransactionType { get; set; }
    }
}
