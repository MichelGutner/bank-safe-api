using BankSafeAPI.Data;
using BankSafeAPI.Entities;
using BankSafeAPI.Interface;
using BankSafeAPI.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();

builder.Services.AddControllers();

var app = builder.Build();

app.MapControllers();
app.Run();
