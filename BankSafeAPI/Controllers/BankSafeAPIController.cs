using BankSafeAPI.Entities;
using Microsoft.AspNetCore.Mvc;

namespace BankSafeAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BankSafeAPIController : ControllerBase
    {
        [HttpGet("users/{cpf}")]
        public IActionResult GetUser(string cpf)
        {
            if (string.IsNullOrEmpty(cpf))
            {
                return BadRequest(
                    new ProblemDetails
                    {
                        Title = "Parâmetro obrigatório",
                        Detail = "O CPF deve ser fornecido para a busca.",
                        Status = StatusCodes.Status400BadRequest,
                    }
                );
            }
            return Ok(new User("Michel", cpf));
        }
    }
}
