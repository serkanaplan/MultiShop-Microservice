using Microsoft.EntityFrameworkCore;
using Order.Domain.Entities;

namespace Order.Persistence.Context;

public class OrderContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => 
    optionsBuilder.UseSqlServer("Server=localhost,1434;Database=MultiShopOrderDB;User Id=sa;Password=Passw0rd;TrustServerCertificate=True;Connect Timeout=30;");

    public DbSet<Address> Addresses { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<Ordering> Orderings { get; set; }
}
