using MenuService.Api.Endpoints;
using MenuService.Domain;
using MenuService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Lägg till EF Core + SQL Server
builder.Services.AddSqlServer<MenuContext>(
    builder.Configuration.GetConnectionString("MenuServiceDb")!);

// Koppla interface till implementation
builder.Services.AddScoped<IPizzaRepository, PizzaRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapPizzaEndpoints();  // dina extension-metoder
app.Run();
