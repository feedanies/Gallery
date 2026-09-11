using Lesson5.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lesson5.Domain.Mapping
{
    public class CustomerMap : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.HasKey(c => c.Id);

            builder.Property(c => c.Fullname)
                .IsRequired(true)
                .HasMaxLength(100)
                .IsUnicode(true);

            builder.Property(c => c.Phone)
                .IsRequired(true)
                .HasMaxLength(10);

            builder.Property(c => c.Email)
                .IsRequired(true)
                .HasMaxLength(100);
            builder.HasIndex(c => c.Email)
                .IsUnique();

            builder.Property(c => c.Id).HasColumnName("CustomerId");
            builder.Property(c => c.Fullname).HasColumnName("Fullname");
            builder.Property(c => c.Phone).HasColumnName("Phone");
            builder.Property(c => c.Email).HasColumnName("Email");

            builder.HasMany(s => s.Sales)
                .WithOne(c => c.Customer)
                .HasForeignKey(s => s.CustomerId)
                .IsRequired(true);
        }
    }
}
