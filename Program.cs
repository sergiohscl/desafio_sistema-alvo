using desafio_sistema_alvo.Services;
using desafio_sistema_alvo.Services.Interfaces;
using desafio_sistema_alvo.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddOpenApi();

builder.Services.AddScoped<IComissaoService, ComissaoService>();

builder.Services.AddScoped<IEstoqueService, EstoqueService>();

var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

//app.UseHttpsRedirection();

app.MapControllers();

app.Run();