using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Interfaces
{
    public interface IOnlineShopContext
    {
        DatabaseFacade Database {  get; }

        public DbSet<BasketEntity> Basket { get; set; }

        public DbSet<ItemEntity> Item { get; set; }

        public DbSet<UserEntity> User { get; set; }

        public DbSet<ValueEntity> Value { get; set; }

        void Migrate();

        void SaveChangesAsync();
    }
}
