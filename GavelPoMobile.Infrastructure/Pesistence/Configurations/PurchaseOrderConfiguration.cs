﻿using GavelPoMobile.Domain.Aggregates;
using GavelPoMobile.Domain.Aggregates.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GavelPoMobile.Infrastructure.Pesistence.Configurations;
public class PurchaseOrderConfiguration : IEntityTypeConfiguration<PurchaseOrder> {

    public void Configure(EntityTypeBuilder<PurchaseOrder> builder) {
        
        builder.HasNoKey()
            .ToView(null);

        builder.Property(o => o.Total)
            .HasColumnType("money")
            .HasPrecision(0);
    }
}
