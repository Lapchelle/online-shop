using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{   /// <summary>
    /// Товар в корзине
    /// </summary>
    public class ValueEntity
    {
        public Guid Id { get; set; }

        public Guid ItemId { get; set; }

        public virtual ItemEntity Item { get; set; }

        public Guid BasketId { get; set; }

        public virtual BasketEntity Basket { get; set; }

        public Guid StatusId { get; set; }
    }
}
