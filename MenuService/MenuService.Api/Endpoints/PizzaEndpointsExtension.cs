namespace MenuService.Api.Endpoints;

public static class PizzaEndpointsExtension
{
    public static IEndpointRouteBuilder MapPizzaEndpoints(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/pizzas").WithTags("Pizza");


        return app;
    }
}