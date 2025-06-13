using System;
using FluentValidation;

namespace OnlineShop.Application.Basket.Commands.SelectItem
{
    public class SelectItemValidator : AbstractValidator<SelectItemCommand>
    {
        public SelectItemValidator()
        {
            RuleFor(SelectItemCommand => 
            SelectItemCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(SelectItemCommand =>
            SelectItemCommand.Item).NotEqual(Guid.Empty);
        }
    }
}
