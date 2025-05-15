namespace OrderService.Domain;

public class OrderItem
{
    public int Id { get; set; }
    public int PizzaId { get; set; }
    public string PizzaName { get; set; } = string.Empty;
    public decimal UnitPrice { get; set; }
    public int Quantity { get; set; }
}