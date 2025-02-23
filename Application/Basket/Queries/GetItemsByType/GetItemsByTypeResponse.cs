using MediatR;
using OnlineShop.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Basket.Queries.GetItemsByType
{
    public class GetItemsByTypeResponse 
    {
        
        public GetItemsByTypeResponse(ICollection<ItemsDto> items)
        {
            Items = items;
        }

        public ICollection<ItemsDto> Items { get; set; }
    }
}
