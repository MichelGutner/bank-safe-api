using BankSafeAPI.Domain.Dto;
using BankSafeAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BankSafeAPI.Interface
{
    public interface IUserService
    {
        Task Create(UserDto userDto);
        Task<User?> GetUser(string CPF);
        List<UserDto> GetAll();
    }
}
