using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    internal class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
           builder
            .Property(t => t.Quantity)
            .IsRequired();

           builder
            .Property(t => t.PricePerShare)
            .IsRequired();

            builder
            .Property<DateTime>("CreatedAt")
            .HasDefaultValueSql("GETDATE()");

            builder
                .Property<DateTime>("UpdatedAt")
                .HasDefaultValueSql("GETDATE()");
        }
    }
}
