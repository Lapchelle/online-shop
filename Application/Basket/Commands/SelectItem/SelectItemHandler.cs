using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OnlineShop.Application.DTOs;
using OnlineShop.Application.RabbitMQSender;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Basket.Commands.SelectItem
{
    public class SelectItemHandler : IRequestHandler<SelectItemCommand>
    {
        private readonly IMediator _mediator;
        private readonly IOnlineShopContext _context;
        private readonly ILogger _logger;
        private readonly RabbitMQCartMessageSender _publisher;

        public SelectItemHandler(IMediator mediator, IOnlineShopContext context, ILogger logger, RabbitMQCartMessageSender publisher)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
        }

        public async Task Handle(SelectItemCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var basketId = await GetBasketFromUser(request.UserId);

                var item = _context.Item
                    .Where(c => c.Id == request.Item)
                    .FirstOrDefault();

                var basket = _context.Basket
                    .Where(t => t.Id == basketId)
                    .FirstOrDefault();

                basket.Items.Add(item);

                basket.Count++;

                _context.SaveChanges();

                var itemForMessage = new ItemsDto(item.Name);

                _publisher.PublishNotification(item.Name);
;
            }
            catch (Exception ex) 
            {
                _logger.LogError($"{DateTime.UtcNow} - в методе " +
                    $"{nameof(SelectItemCommand)} произошла ошибка: {ex.Message}");
            }
        }

        public async Task<Guid> GetBasketFromUser(Guid id)
        {
            var user = _context.User.Where(t => t.Id == id).FirstOrDefault();
              
            return user.BasketId;
        }
    }
}
