using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Basket.Queries.GetItemsByType
{
    public class GetItemsByTypeQuery : IRequest<GetItemsByTypeResponse>
    {
        public GetItemsByTypeQuery(Guid type)
        {
            TypeId = type;
        }

        public GetItemsByTypeQuery()
        {
            
        }

        public Guid TypeId { get; set; }

    }
}
