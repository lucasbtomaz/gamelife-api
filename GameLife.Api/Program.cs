using GameLife.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AdicionarInfraestrutura(
    builder.Configuration.GetConnectionString("GameLife")
    ?? throw new InvalidOperationException("A conexão 'GameLife' não foi configurada."));

var app = builder.Build();

app.MapControllers();

app.UseHttpsRedirection();
app.Run();

public partial class Program;
