using BankSafeAPI.Domain.Dto.Input;
using BankSafeAPI.Domain.Dto.Output;

namespace BankSafeAPI.Interface
{
    public interface ITransactionService
    {
        Task CreateTransaction(CreateTransactionInputDto query);
        Task<TransactionOutputDto> GetTransactions(GetTransactionsInputDto query);
    }
}
