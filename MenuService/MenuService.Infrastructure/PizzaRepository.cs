using MenuService.Domain;
using Microsoft.EntityFrameworkCore;

namespace MenuService.Infrastructure;

public class PizzaRepository(MenuContext dbContext) : IPizzaRepository
{
    public async Task<IEnumerable<Pizza>> GetAllAsync(CancellationToken ct)
    {
        var pizzas = await dbContext.Pizzas.AsNoTracking().ToListAsync(ct);
        return pizzas;
    }

    public async Task<Pizza?> GetByIdAsync(int id, CancellationToken ct)
    {
        var pizza = await dbContext.Pizzas.FirstOrDefaultAsync(p => p.Id == id, ct);
        return pizza;
    }

    public async Task<Pizza> AddAsync(Pizza pizza, CancellationToken ct)
    {
        await dbContext.Pizzas.AddAsync(pizza, ct);
        await dbContext.SaveChangesAsync(ct);
        return pizza;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct)
    {
        var pizza = await dbContext.Pizzas.FindAsync(new object[] { id }, ct);
        if (pizza == null)
        {
            return false;
        }
        dbContext.Pizzas.Remove(pizza);
        await dbContext.SaveChangesAsync(ct);
        return true;
    }

    public async Task<bool> UpdateAsync(Pizza pizza, CancellationToken ct)
    {
        var existingPizza = await dbContext.Pizzas.FindAsync(new object[] { pizza.Id }, ct);
        if (existingPizza == null)
        {
            return false;
        }
        dbContext.Entry(existingPizza).CurrentValues.SetValues(pizza);
        await dbContext.SaveChangesAsync(ct);
        return true;
    }
}