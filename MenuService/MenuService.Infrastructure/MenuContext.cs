using MenuService.Domain;
using Microsoft.EntityFrameworkCore;

namespace MenuService.Infrastructure;

public class MenuContext(DbContextOptions<MenuContext> options) : DbContext(options)
{
    public DbSet<Pizza> Pizzas { get; set; }
}