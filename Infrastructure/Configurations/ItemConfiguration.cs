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
    public class ItemConfiguration : IEntityTypeConfiguration<ItemEntity>
    {
        public void Configure(EntityTypeBuilder<ItemEntity> builder)
        {
            builder.ToTable("Item");

            builder.HasKey(t => t.Id);

            builder.HasIndex(t => t.TypeId).HasDatabaseName("TypeId_Index");

            builder.Property(t => t.Name).HasColumnName("Name");
            builder.Property(t => t.Price).HasColumnName("Price");
            builder.Property(t => t.Rating).HasColumnName("Rating");
            builder.Property(t => t.Image).HasColumnName("Image");
            builder.Property(t => t.TypeId).HasColumnName("TypeId");
            builder.Property(t => t.BasketId).HasColumnName("BasketId");

            builder.HasOne(t => t.Basket)
                .WithMany(t => t.Items)
                .OnDelete(DeleteBehavior.NoAction)
                .HasConstraintName($"FK_{nameof(BasketEntity)}_{nameof(ItemEntity)}");
        }
    }
}
