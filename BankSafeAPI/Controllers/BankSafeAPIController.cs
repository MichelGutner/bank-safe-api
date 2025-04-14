using BankSafeAPI.Data;
using BankSafeAPI.Domain.Dto;
using BankSafeAPI.Entities;
using BankSafeAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BankSafeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BankSafeAPIController(AppDbContext context, IUserService userService)
        : ControllerBase
    {
        private readonly AppDbContext _context = context;
        private readonly IUserService _userService = userService;

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return [.. _context.Users];
        }

        [Route("Users")]
        [HttpPost]
        public async Task<IActionResult> Create(UserDto user)
        {
            if (user == null)
                return BadRequest();
            try
            {
                await _userService.Create(user);
                Console.WriteLine("testando");
                return CreatedAtAction(nameof(Get), user);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [Route("Users/{CPF}")]
        [HttpGet]
        public async Task<IActionResult> GetUser(string CPF)
        {
            if (CPF.IsNullOrEmpty())
                return BadRequest();

            try
            {
                User? user = await _userService.GetUser(CPF);
                return Ok(user);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
