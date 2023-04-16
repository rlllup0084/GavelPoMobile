using Microsoft.EntityFrameworkCore;

namespace GavelPoMobile.Infrastructure.Pesistence;
public class GavelPoMobileDbContext : DbContext {
    public GavelPoMobileDbContext(DbContextOptions<GavelPoMobileDbContext> options) : base(options) { }
    protected override void OnModelCreating(ModelBuilder modelBuilder) {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(GavelPoMobileDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
