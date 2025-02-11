using Microsoft.EntityFrameworkCore;

namespace CharacterVaulBack.Models.Context;

public class ConnectionContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Sheet> Sheets { get; set; }
    public DbSet<Skill> Skill { get; set; }

    public ConnectionContext(DbContextOptions<ConnectionContext> options)
        : base(options)
    {
        
    }

    public ConnectionContext() {}
    
}