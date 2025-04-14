using BankSafeAPI.Data;
using BankSafeAPI.Domain.Dto;
using BankSafeAPI.Domain.Enums;
using BankSafeAPI.Entities;
using BankSafeAPI.Interface;
using Microsoft.EntityFrameworkCore;

namespace BankSafeAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AppDbContext _context;

        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public async Task Create(UserDto user)
        {
            var passwordHash = BCrypt.Net.BCrypt.HashPassword(user.Password);

            var newUser = new User
            {
                Username = user.Name,
                CPF = user.CPF,
                Email = user.Email,
                Password = passwordHash,
            };

            _context.Users.Add(newUser);
            await _context.SaveChangesAsync();

            var newAccount = new Account
            {
                UserId = newUser.UserId,
                AccountNumber = GenerateAccountNumber(),
                Agency = "0001",
                AccountType = AccountType.checking,
                Balance = 0.00m,
            };

            _context.Accounts.Add(newAccount);
            await _context.SaveChangesAsync();
        }

        public async Task<User?> GetUser(string CPF)
        {
            User? user = await _context.Users.FirstOrDefaultAsync(user => user.CPF == CPF);
            if (user != null)
            {
                var accounts = _context.Accounts.Where(a => a.UserId == user.UserId).ToList();
                if (accounts != null)
                    user.Accounts = accounts;
            }

            return user;
        }

        public List<UserDto> GetAll()
        {
            throw new NotImplementedException();
        }

        private static string GenerateAccountNumber()
        {
            return new Random().Next(10000, 99999).ToString() + "-1";
        }
    }
}
