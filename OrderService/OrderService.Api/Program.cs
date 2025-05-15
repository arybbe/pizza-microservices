using OrderService.Api.Endpoints;
using OrderService.Domain;
using OrderService.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

// Lägg till EF Core + SQL Server
builder.Services.AddSqlServer<OrderContext>(
    builder.Configuration.GetConnectionString("OrderServiceDb")!);

// Koppla interface till implementation
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapOrderEndpoints();  // dina extension-metoder
app.Run();
