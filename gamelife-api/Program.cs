using Microsoft.EntityFrameworkCore;
using gamelife_api.Context;
using gamelife_api.Models;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();

var connectionString =
    builder.Configuration.GetConnectionString("GameLife")
    ?? throw new InvalidOperationException(
        "A connection string 'GameLife' não foi encontrada.");

builder.Services.AddDbContext<GameLifeDbContext>(options =>
    options.UseMySQL(connectionString));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await app.RunAsync();
