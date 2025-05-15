using Microsoft.EntityFrameworkCore;
using OrderService.Domain;

namespace OrderService.Infrastructure;

public class OrderRepository(OrderContext dbContext) : IOrderRepository
{
    public async Task<Order?> GetByIdAsync(int id, CancellationToken ct)
    {
        var order = await dbContext.Orders
            .Include(o => o.Items)
            .FirstOrDefaultAsync(o => o.Id == id, ct);

        return order;
    }

    public async Task<Order> AddAsync(Order order, CancellationToken ct)
    {
        await dbContext.Orders.AddAsync(order, ct);
        await dbContext.SaveChangesAsync(ct);
        return order;
    }

    public async Task<IEnumerable<Order>> GetAllAsync(CancellationToken ct)
    {
        var orders = await dbContext.Orders
            .Include(o => o.Items)
            .AsNoTracking()
            .ToListAsync(ct);

        return orders;
    }

    public async Task<bool> DeleteAsync(int id, CancellationToken ct)
    {
        var order = await dbContext.Orders.FindAsync(new object[] { id }, ct);
        if (order == null)
        {
            return false;
        }
        dbContext.Orders.Remove(order);
        await dbContext.SaveChangesAsync(ct);
        return true;
    }

    public async Task<bool> UpdateAsync(Order order, CancellationToken ct)
    {
        var existingOrder = await dbContext.Orders.FindAsync(new object[] { order.Id }, ct);
        if (existingOrder == null)
        {
            return false;
        }
        dbContext.Entry(existingOrder).CurrentValues.SetValues(order);
        await dbContext.SaveChangesAsync(ct);
        return true;
    }
}