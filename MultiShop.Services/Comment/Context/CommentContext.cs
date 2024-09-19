using Comment.Entities;
using Microsoft.EntityFrameworkCore;

namespace Comment.Context;

public class CommentContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=localhost,1442;Database=MultiShopCommentDb;User Id=sa;Password=Passw0rd;TrustServerCertificate=True;Connect Timeout=30;");
    }
    public DbSet<UserComment> UserComments { get; set; }
}
