using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.DTOs
{
    public class ItemsDto
    {
        public ItemsDto(string name, int price, int rating, string typeName)
        {
            Name = name;
            Price = price;
            Rating = rating;
            TypeName = typeName;
        }

       

        public string Name { get; set; }

        public int Price { get; set; }

        public int Rating { get; set; }

        public string TypeName { get; set; }
    }
}
