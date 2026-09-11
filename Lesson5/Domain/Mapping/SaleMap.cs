using Lesson5.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson5.Domain.Mapping
{
    public class SaleMap : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder.ToTable("Sales");
            builder.HasKey(s => s.Id);

            builder.Property(s=>s.SaleDate)
                .IsRequired(true)
                .HasDefaultValueSql("GETDATE()");

            builder.Property(s => s.SalePrice)
                .IsRequired(true);
            builder.HasCheckConstraint("Sale_Price", "[SalePrice] > 0");


            builder.Property(s => s.Id).HasColumnName("SaleId");
            builder.Property(s => s.SaleDate).HasColumnName("SaleDate");
            builder.Property(s => s.SalePrice).HasColumnName("SalePrice");
            builder.Property(s => s.CarId).HasColumnName("CarId");
            builder.Property(s => s.CustomerId).HasColumnName("CustomerId");
        }
    }
}
