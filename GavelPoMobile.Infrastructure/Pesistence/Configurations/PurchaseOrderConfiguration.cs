using GavelPoMobile.Domain.Aggregates.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GavelPoMobile.Infrastructure.Pesistence.Configurations;
public class PurchaseOrderConfiguration : IEntityTypeConfiguration<PurchaseOrderDetail> {
    public void Configure(EntityTypeBuilder<PurchaseOrderDetail> builder) {

        builder.HasNoKey()
            .ToView(null);

        builder.Property(o => o.Total)
            .HasColumnType("money")
            .HasPrecision(2);

        builder.Property(o => o.Quantity)
            .HasColumnType("money")
            .HasPrecision(2);

        builder.Property(o => o.Cost)
            .HasColumnType("money")
            .HasPrecision(2);
    }
}
