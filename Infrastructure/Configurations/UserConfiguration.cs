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
    public class UserConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("User");

            builder.HasKey(t => t.Id);

            builder.HasIndex(t => t.BasketId).HasDatabaseName("BasketId_Index");
            builder.HasIndex(t => t.RoleId).HasDatabaseName("RoleId_Index");

            builder.Property(t => t.FirstName).HasColumnName("FirstName");
            builder.Property(t => t.LastName).HasColumnName("LastName");
            builder.Property(t => t.Email).HasColumnName("Email");
            builder.Property(t => t.Password).HasColumnName("Password");
            builder.Property(t => t.RoleId).HasColumnName("RoleId");
            builder.Property(t => t.BasketId).HasColumnName("BasketId");
        }
    }
}
