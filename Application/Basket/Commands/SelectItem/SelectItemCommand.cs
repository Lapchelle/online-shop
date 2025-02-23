using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Basket.Commands.SelectItem
{
    public class SelectItemCommand : IRequest
    {
        public SelectItemCommand(Guid item, Guid userId)
        {
            Item = item;
            UserId = userId;
        }

        public Guid Item { get; set; }
                
        public Guid UserId { get; set; }
    }
}
