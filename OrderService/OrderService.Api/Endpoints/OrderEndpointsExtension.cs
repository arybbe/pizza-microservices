using OrderService.Domain;

namespace OrderService.Api.Endpoints;

public static class OrderEndpointsExtension
{
    public static IEndpointRouteBuilder MapOrderEndpoints(this IEndpointRouteBuilder app)
    {
        var grp = app.MapGroup("/api/orders");

        grp.MapGet("/", async (IOrderRepository repo, CancellationToken ct) =>
            Results.Ok(await repo.GetAllAsync(ct)));

        grp.MapGet("/{id:int}", async (int id, IOrderRepository repo, CancellationToken ct) =>
            await repo.GetByIdAsync(id, ct) is { } order
                ? Results.Ok(order)
                : Results.NotFound());

        grp.MapPost("/", async (Order order, IOrderRepository repo, CancellationToken ct) =>
            Results.Created($"/api/orders/{order.Id}", await repo.AddAsync(order, ct)));

        grp.MapPut("/", async (Order order, IOrderRepository repo, CancellationToken ct) =>
            await repo.UpdateAsync(order, ct)
                ? Results.Ok(order)
                : Results.NotFound());

        grp.MapDelete("/{id:int}", async (int id, IOrderRepository repo, CancellationToken ct) =>
            await repo.DeleteAsync(id, ct)
                ? Results.NoContent()
                : Results.NotFound());

        return app;
    }
}