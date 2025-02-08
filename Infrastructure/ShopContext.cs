using Application.Common.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class ShopContext : DbContext, IOnlineShopContext
    {
        protected string _defaultSchema = "ONLINE_SHOP";

        public DbSet<BasketEntity> Basket { get; set; }
        public DbSet<ItemEntity> Item { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<TypeEntity> Type { get; set; }
        public DbSet<RolesEntity> Roles { get; set; }

        public ShopContext()
        {

        }
        
        public ShopContext(DbContextOptions<ShopContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties().Where(p => p.IsPrimaryKey()))
                {
                    property.ValueGenerated = ValueGenerated.Never;
                }
            }

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ShopContext).Assembly);
        }
        protected static DbContextOptions<T> ChangeOptionsType<T>(DbContextOptions options) where T : DbContext
        {
            return new DbContextOptionsBuilder<T>()
                        .Options;
        }

        public void Migrate()
        {
            Database.Migrate();
        }

        public void SaveChangesAsync()
        {
            SaveChanges();
        }
    }
}
