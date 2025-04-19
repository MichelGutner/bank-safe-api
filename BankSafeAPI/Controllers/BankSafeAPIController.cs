using BankSafeAPI.Data;
using BankSafeAPI.Domain.Dto;
using BankSafeAPI.Domain.Dto.Input;
using BankSafeAPI.Entities;
using BankSafeAPI.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace BankSafeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BankSafeAPIController(
        AppDbContext context,
        IUserService userService,
        ITransactionService transactionService
    ) : ControllerBase
    {
        private readonly AppDbContext _context = context;
        private readonly IUserService _userService = userService;
        private readonly ITransactionService _transactionService = transactionService;

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

        [Route("Transaction")]
        [HttpPost]
        public async Task<IActionResult> CreateTransaction(CreateTransactionInputDto query)
        {
            await _transactionService.Create(query);
            return CreatedAtAction(nameof(Get), query);
        }

        [Route("Transaction/{id}")]
        [HttpGet]
        public async Task<IActionResult> GetTransaction(int id)
        {
            var transaction = await _transactionService.Get(id);
            return Ok(transaction);
        }

        [Route("Transaction")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Transaction>>> GetTransactions(
            [FromQuery] GetTransactionsInputDto filters
        )
        {
            var transactions = await _transactionService.GetTransactions(filters);
            return Ok(transactions);
        }
    }
}
