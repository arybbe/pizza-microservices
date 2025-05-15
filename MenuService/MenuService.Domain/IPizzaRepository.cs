namespace MenuService.Domain;

public interface IPizzaRepository
{
    Task<IEnumerable<Pizza>> GetAllAsync(CancellationToken ct);
    Task<Pizza?> GetByIdAsync(int id, CancellationToken ct);
    Task<Pizza> AddAsync(Pizza pizza, CancellationToken ct);
    Task<bool> DeleteAsync(int id, CancellationToken ct);
    Task<bool> UpdateAsync(Pizza pizza, CancellationToken ct);
}