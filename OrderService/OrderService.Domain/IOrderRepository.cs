namespace OrderService.Domain;

public interface IOrderRepository
{
    Task<Order?> GetByIdAsync(int id, CancellationToken ct);
    Task<Order> AddAsync(Order order, CancellationToken ct);
    Task<IEnumerable<Order>> GetAllAsync(CancellationToken ct);
    Task<bool> DeleteAsync(int id, CancellationToken ct);
    Task<bool> UpdateAsync(Order order, CancellationToken ct);
}