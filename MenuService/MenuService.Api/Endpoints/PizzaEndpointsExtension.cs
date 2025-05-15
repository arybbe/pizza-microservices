using MenuService.Domain;

namespace MenuService.Api.Endpoints;

public static class PizzaEndpointsExtension
{
    public static IEndpointRouteBuilder MapPizzaEndpoints(this IEndpointRouteBuilder app)
    {
        var grp = app.MapGroup("/api/pizzas");

        grp.MapGet("/", async (IPizzaRepository repo, CancellationToken ct) =>
            Results.Ok(await repo.GetAllAsync(ct)));

        grp.MapGet("/{id:int}", async (int id, IPizzaRepository repo, CancellationToken ct) =>
            await repo.GetByIdAsync(id, ct) is { } pizza
                ? Results.Ok(pizza)
                : Results.NotFound());

        grp.MapPost("/", async (Pizza pizza, IPizzaRepository repo, CancellationToken ct) =>
            Results.Created($"/api/pizzas/{pizza.Id}", await repo.AddAsync(pizza, ct)));

        grp.MapPut("/", async (Pizza pizza, IPizzaRepository repo, CancellationToken ct) =>
            await repo.UpdateAsync(pizza, ct)
                ? Results.Ok(pizza)
                : Results.NotFound());

        grp.MapDelete("/{id:int}", async (int id, IPizzaRepository repo, CancellationToken ct) =>
            await repo.DeleteAsync(id, ct)
                ? Results.NoContent()
                : Results.NotFound());

        return app;
    }
}