using GavelPoMobile.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GavelPoMobile.Infrastructure.Pesistence.Configurations;
public class UserConfiguration : IEntityTypeConfiguration<User> {
    public void Configure(EntityTypeBuilder<User> builder) {
        builder
            .HasNoKey()
            .ToView("vPoApprover");

        builder.Property(e => e.Email).HasMaxLength(100);
        builder.Property(e => e.Name).HasMaxLength(100);
        builder.Property(e => e.No).HasMaxLength(100);
        builder.Property(e => e.Popassword)
            .HasMaxLength(100)
            .HasColumnName("POPassword");
    }
}
