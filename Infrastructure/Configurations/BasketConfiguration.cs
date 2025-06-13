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
    public class BasketConfiguration : IEntityTypeConfiguration<BasketEntity>
    {
        public void Configure(EntityTypeBuilder<BasketEntity> builder)
        {
            builder.ToTable("Basket");

            builder.HasKey(t => t.Id);
            builder.Property(t => t.Count).HasColumnName("Count").HasDefaultValue(0).HasComment("Количество");
        }
    }
}
