using System;
using GraphQL.Types;
using System.Linq;
using Orders.Services;

namespace Orders.Schema
{
    public class BreweryQuery: ObjectGraphType<object>
    {
        public BreweryQuery(
                            IBreweryService brewery,
                            IReviewService review,
                            IBeerTypeService beerType,
                            IUserService users)
        {
            Name = "Query";
            Field<ListGraphType<BreweryType>>(
                "brewery",
                resolve: context => brewery.Get()
            );
            Field<ListGraphType<UserType>>(
                "user",
                resolve: context => users.Get()
            );
        }
    }
}