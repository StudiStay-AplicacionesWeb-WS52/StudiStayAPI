using Microsoft.EntityFrameworkCore;
using StudiStayAPI.Rooms.Domain.Models;

namespace StudiStayAPI.Shared.Persistence.Contexts;

public class AppDbContext : DbContext
{
    //define las tablas de la base de datos
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    
    public AppDbContext(DbContextOptions options) : base(options) {}
    
    //configura las tablas de la base de datos
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        //aplica la convencion de nombres snake_case
        optionsBuilder.UseSnakeCaseNamingConvention(); 
    }
}