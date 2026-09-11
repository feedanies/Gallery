using Lesson5.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson5.Domain.Mapping
{
    public class CarMap : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.ToTable("Cars");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Model)
                .IsRequired(true)
                .HasMaxLength(100)
                .IsUnicode(true);

            builder.Property(c => c.Year)
                .IsRequired(true);
            builder.HasCheckConstraint("Car_Year", "[Year] <= YEAR(GETDATE())");

            builder.Property(c => c.Price)
                .IsRequired(true);
            builder.HasCheckConstraint("Car_Price", "[Price]>0");

            builder.Property(c => c.Color)
                .HasMaxLength(30);

            builder.Property(c => c.IsNew)
                .IsRequired(true)
                .HasDefaultValue(false);


            builder.Property(c => c.Id).HasColumnName("CarId");
            builder.Property(c => c.Model).HasColumnName("Model");
            builder.Property(c => c.Year).HasColumnName("Year");
            builder.Property(c => c.Price).HasColumnName("Price");
            builder.Property(c => c.Color).HasColumnName("Color");
            builder.Property(c => c.IsNew).HasColumnName("IsNew");

            builder.HasMany(s => s.Sales)
                .WithOne(c => c.Car)
                .HasForeignKey(s => s.CarId)
                .IsRequired(true);

        }
    }
}
