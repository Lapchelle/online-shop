using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Infrastructure.Persistence.Providers.Postgresql
{
    public class OnlineShopDbContextPostgresql : ShopContext
    {
        private readonly IConfiguration _configuration;

        public OnlineShopDbContextPostgresql(
            DbContextOptions<OnlineShopDbContextPostgresql> options,
            IConfiguration configuration)
            : base(ChangeOptionsType<ShopContext>(options))
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            base.OnConfiguring(options);
            options.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"))
                .EnableSensitiveDataLogging()
                .EnableDetailedErrors()
                .LogTo(message => Debug.WriteLine(message), LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(_defaultSchema);
            base.OnModelCreating(modelBuilder);
        }
    }
}
