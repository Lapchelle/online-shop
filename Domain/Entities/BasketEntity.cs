using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{   /// <summary>
    /// Корзина
    /// </summary>
    public class BasketEntity
    {
        public Guid Id { get; set; }

        public int Count { get; set; }

        public virtual ICollection<ValueEntity> Values { get; set; }
    }
}
