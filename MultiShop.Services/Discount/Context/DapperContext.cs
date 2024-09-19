using Discount.Entites;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace Discount.Context;

public class DapperContext(IConfiguration configuration) : DbContext
{
    private readonly string _connectionString = configuration.GetConnectionString("DefaultConnection")!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder.UseSqlServer("Server=localhost,1433;Database=MultiShopDiscountDb;User Id=sa;Password=Passw0rd;TrustServerCertificate=True;Connect Timeout=30;");
    
    public DbSet<Coupon> Coupons { get; set; }

    public string ConnectionString => _connectionString;

    public IDbConnection CreateConnection() => new SqlConnection(_connectionString);
}