using MediatR;
using Microsoft.AspNetCore.Mvc;
using online_shop.Models;
using OnlineShop.Application.Basket.Commands.SelectItem;
using OnlineShop.Application.Basket.Queries.GetItemsByType;
using OnlineShop.Application.DTOs;
using System.Net.Mime;

namespace online_shop.Controllers
{
    [ApiController]
    [Route("services/[controller]/[action]")]
    public class ItemController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ItemController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        [HttpPost]
        [Produces(MediaTypeNames.Application.Json)]
        public async Task<IActionResult> SelectItems([FromBody] ItemModel request)
        {
            await _mediator.Send(new SelectItemCommand(request.UserId, request.ItemId));

            return Ok();
        }

        [HttpGet]
        [Produces(MediaTypeNames.Application.Json)]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetItemsByTypeResponse))]
        public async Task<IActionResult> GetItemByType([FromQuery] GetItemsByTypeQuery query)
        {
            var respose = await _mediator.Send(query);
            return new JsonResult(respose);
        }
    }
}
