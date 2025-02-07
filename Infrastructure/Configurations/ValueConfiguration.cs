using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class ValueConfiguration : IEntityTypeConfiguration<ValueEntity>
    {
        public void Configure(EntityTypeBuilder<ValueEntity> builder)
        {
            builder.ToTable("Value");

            builder.HasKey(t => t.Id);

            builder.HasIndex(t => t.ItemId).HasDatabaseName("ItemId_Index");

            builder.Property(t => t.ItemId).HasColumnName("ItemId");
            builder.Property(t => t.BasketId).HasColumnName("BasketId");
            builder.Property(t => t.StatusId).HasColumnName("StatusId");

            builder.HasOne(t => t.Basket)
                .WithMany(t => t.Values)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName($"FK_{nameof(BasketEntity)}_{nameof(ValueEntity)}");
        }
    }
}
