using BankSafeAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankSafeAPI.Data
{
    public class AppDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}
