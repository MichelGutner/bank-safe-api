using BankSafeAPI.Data;
using BankSafeAPI.Domain.Dto.Input;
using BankSafeAPI.Domain.Dto.Output;
using BankSafeAPI.Entities;
using BankSafeAPI.Interface;
using Microsoft.EntityFrameworkCore;

namespace BankSafeAPI.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly AppDbContext _context;

        public TransactionService(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(CreateTransactionInputDto query)
        {
            var account = _context.Accounts.Where(a => a.AccountId == query.AccountId);
            if (!account.Any())
                throw new InvalidOperationException("Conta não encotrada");

            var newTransaction = new Transaction
            {
                TransactionType = query.TransactionType,
                Amount = query.Amount,
                AccountId = query.AccountId,
                Description = query.Description,
            };

            _context.Transactions.Add(newTransaction);
            await _context.SaveChangesAsync();
        }

        public async Task<Transaction> Get(int id)
        {
            var transaction = await _context
                .Transactions.Where(t => t.TransactionId == id)
                .FirstOrDefaultAsync();

            if (transaction == null)
                throw new ArgumentException($"Transação com id: {id} não encontrada");

            return transaction;
        }
    }
}
