using System;
using FluentValidation;

namespace OnlineShop.Application.Basket.Queries.GetItemsByType
{
    public class GetItemsByTypeValidator : AbstractValidator<GetItemsByTypeQuery>
    {
        public GetItemsByTypeValidator()
        {
            RuleFor(GetItemsByTypeQuery =>
            GetItemsByTypeQuery.TypeId).NotEqual(Guid.Empty);
        }
    }
}
