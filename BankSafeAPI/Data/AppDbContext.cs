using BankSafeAPI.Entities;
using Microsoft.EntityFrameworkCore;

namespace BankSafeAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options)
            : base(options) { }

        public DbSet<BankAccount> BankAccounts { get; set; }
    }
}
