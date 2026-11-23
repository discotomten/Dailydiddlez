using Microsoft.EntityFrameworkCore;

namespace blazorHome.Data;

public class AppDbContext : DbContext
{
    public DbSet<TodoModell> Todos => Set<TodoModell>();

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }
    
}