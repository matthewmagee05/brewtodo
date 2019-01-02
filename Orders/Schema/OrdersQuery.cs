using System;
using GraphQL.Types;
using System.Linq;
using Orders.Services;

namespace Orders.Schema
{
    public class OrdersQuery: ObjectGraphType<object>
    {
        public OrdersQuery(IOrderService orders,
                            IBreweryService brewery,
                            IReviewService review,
                            IBeerTypeService beerType,
                            IUserService users)
        {
            Name = "Query";
            Field<ListGraphType<OrderType>>(
                "orders",
                resolve: context => orders.GetOrdersAsync()
            );
            Field<ListGraphType<BreweryType>>(
                "brewery",
                resolve: context => brewery.Get()
            );
            Field<ListGraphType<ReviewType>>(
                "review",
                resolve: context => review.Get()
            );
            Field<ListGraphType<BeerTypeType>>(
                "beertype",
                resolve: context => beerType.Get()
            );
            Field<ListGraphType<UserType>>(
                "user",
                resolve: context => users.Get()
            );
        }
    }
}