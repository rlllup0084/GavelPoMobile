using GavelPoMobile.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace GavelPoMobile.Infrastructure.Pesistence;
public class GavelPoMobileDbContext : DbContext {
    public GavelPoMobileDbContext(DbContextOptions<GavelPoMobileDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GavelPoMobileDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
