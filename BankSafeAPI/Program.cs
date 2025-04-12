using BankSafeAPI.Data;
using BankSafeAPI.Entities;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();

var app = builder.Build();

// builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("BankDb"));

app.UseHttpsRedirection();
app.UseAuthentication();

app.MapControllers();

app.Run();
