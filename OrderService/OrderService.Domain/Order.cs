namespace OrderService.Domain;

public class Order
{
    public int Id { get; set; }
    public DateTime CreatedUtc { get; set; } = DateTime.UtcNow;
    public ICollection<OrderItem> Items { get; set; }
    public decimal Total => Items.Sum(i => i.UnitPrice * i.Quantity);
}