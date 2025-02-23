using Application.Common.Interfaces;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Microsoft.Extensions.Logging;
using OnlineShop.Application.Basket.Commands.SelectItem;
using OnlineShop.Application.DTOs;
using OnlineShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Basket.Queries.GetItemsByType
{
    public class GetItemsByTypeHandler : IRequestHandler<GetItemsByTypeQuery, GetItemsByTypeResponse>
    {
        public IOnlineShopContext _context;
        public ILogger _logger;
        public IMediator _mediator;
        public GetItemsByTypeHandler(IOnlineShopContext context, ILogger logger, IMediator mediator)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger)); 
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<GetItemsByTypeResponse> Handle(GetItemsByTypeQuery request, CancellationToken cancellationToken)
        {   
            try
            {
                var items = _context.Item.Where(i => i.TypeId == request.TypeId).ToList();

                var itemDtos = new List<ItemsDto>();

                foreach (var item in items)
                {
                    var itemDto = new ItemsDto(item.Name,
                        item.Price,
                        item.Rating,
                        item.Types.Name);

                    itemDtos.Add(itemDto);
                }

                return new GetItemsByTypeResponse(itemDtos);
            }
            catch (Exception ex) 
            {
                _logger.LogError($"{DateTime.UtcNow} - в методе " +
                    $"{nameof(GetItemsByTypeQuery)} произошла ошибка: {ex.Message}");
                
                return null;
            }
        }
    }
}
