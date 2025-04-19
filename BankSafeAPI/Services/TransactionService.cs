using BankSafeAPI.Data;
using BankSafeAPI.Domain.Dto.Input;
using BankSafeAPI.Entities;
using BankSafeAPI.Infrastructure.Shared;
using BankSafeAPI.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

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

        public async Task<IEnumerable<Transaction>> GetTransactions(GetTransactionsInputDto filters)
        {
            var predicate = PredicateBuilder.True<Transaction>();

            if (filters.AccountId.HasValue)
            {
                predicate = predicate.And(t => t.AccountId == filters.AccountId);
            }
            if (filters.MinAmount.HasValue)
            {
                predicate = predicate.And(t => t.Amount >= filters.MinAmount);
            }
            if (filters.MaxAmount.HasValue)
            {
                predicate = predicate.And(t => t.Amount <= filters.MaxAmount);
            }
            if (!filters.TransactionType.IsNullOrEmpty())
            {
                predicate = predicate.And(t => t.TransactionType == filters.TransactionType);
            }
            if (filters.StartDate.HasValue)
            {
                predicate = predicate.And(t =>
                    DateOnly.FromDateTime(t.CreatedAt) >= filters.StartDate
                );
            }
            if (filters.EndDate.HasValue)
            {
                predicate = predicate.And(t =>
                    DateOnly.FromDateTime(t.CreatedAt) <= filters.EndDate
                );
            }

            return await _context.Transactions.Where(predicate).ToListAsync();
        }
    }
}
