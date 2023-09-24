using Microsoft.EntityFrameworkCore;
using NetTopologySuite;
using webApiPostgrees.Model;

namespace webApiPostgrees;

public class AplicationDbContext : DbContext
{
    public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
        : base(options) { }

    public DbSet<Predio> Predios { get; set; }
    public DbSet<Suscriptor> Suscriptores { get; set; }

 
}

