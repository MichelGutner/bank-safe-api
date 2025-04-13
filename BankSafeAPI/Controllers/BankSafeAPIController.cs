using BankSafeAPI.Data;
using BankSafeAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BankSafeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BankSafeAPIController(AppDbContext context) : ControllerBase
    {
        private readonly AppDbContext _context = context;

        [HttpGet]
        public IEnumerable<User> Get()
        {
            return [.. _context.Users];
        }

        [HttpPost]
        public IActionResult Post(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return CreatedAtAction(nameof(Get), new { cpf = user.Cpf }, user);
        }

        // [HttpGet("users/{cpf}")]
        // public IActionResult GetUser(string cpf)
        // {
        //     if (string.IsNullOrEmpty(cpf))
        //     {
        //         return BadRequest(
        //             new ProblemDetails
        //             {
        //                 Title = "Parâmetro obrigatório",
        //                 Detail = "O CPF deve ser fornecido para a busca.",
        //                 Status = StatusCodes.Status400BadRequest,
        //             }
        //         );
        //     }
        //     return Ok(new User("Michel", cpf));
        // }
    }
}
