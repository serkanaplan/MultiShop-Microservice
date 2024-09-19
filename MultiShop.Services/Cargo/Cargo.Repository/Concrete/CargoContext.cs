using Cargo.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Cargo.Repository.Concrete;

public class CargoContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1433;Database=MultiShopCargoDB;User Id=sa;Password=Passw0rd;TrustServerCertificate=True;Connect Timeout=30;");
    }
    public DbSet<CargoCompany> CargoCompanies { get; set; }
    public DbSet<CargoDetail> CargoDetails { get; set; }
    public DbSet<CargoCustomer> CargoCustomers { get; set; }
    public DbSet<CargoOperation> CargoOperations { get; set; }
}
