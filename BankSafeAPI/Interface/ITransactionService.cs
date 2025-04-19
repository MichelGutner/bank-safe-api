using BankSafeAPI.Domain.Dto.Input;
using BankSafeAPI.Domain.Dto.Output;
using BankSafeAPI.Entities;

namespace BankSafeAPI.Interface
{
    public interface ITransactionService
    {
        Task Create(CreateTransactionInputDto query);
        Task<Transaction> Get(int id);
    }
}
