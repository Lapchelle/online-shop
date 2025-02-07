using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{   /// <summary>
    /// Пользователь
    /// </summary>
    public class UserEntity
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public Guid RoleId { get; set; }

        public virtual RolesEntity Roles { get; set; }

        public Guid BasketId { get; set; }

        public virtual BasketEntity Basket { get; set; }
    }
}
