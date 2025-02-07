using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Domain.Entities
{   /// <summary>
    /// Тип товара
    /// </summary>
    public class TypeEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
