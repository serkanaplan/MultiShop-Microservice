using Message.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Message.DAL.Context;

public class MessageContext(DbContextOptions<MessageContext> options) : DbContext(options)
{
    public DbSet<UserMessage> UserMessages { get; set; }
}
