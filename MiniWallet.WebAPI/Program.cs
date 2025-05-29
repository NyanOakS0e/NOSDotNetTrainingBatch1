using Microsoft.EntityFrameworkCore;
using MiniWallet.Database.Models;
using MiniWallet.Domain.Features;
using MiniWallet.Domain.Features.CheckBalanceServices;
using MiniWallet.Domain.Features.DepositServices;
using MiniWallet.Domain.Features.TransferServices;
using MiniWallet.Domain.Features.WalletServices;
using MiniWallet.Domain.Features.WithDrawServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));

builder.Services.AddScoped<RegisterWalletService>();
builder.Services.AddScoped<DepositService>();
builder.Services.AddScoped<WithdrawService>();
builder.Services.AddScoped<CheckBalanceService>();
builder.Services.AddScoped<TransferService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
