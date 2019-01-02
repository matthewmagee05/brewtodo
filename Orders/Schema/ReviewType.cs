using System;
using GraphQL.Types;
using Orders.Models;
using Orders.Services;

namespace Orders.Schema
{
    public class ReviewType: ObjectGraphType<Review>
    {
        public ReviewType(IUserService users, IBreweryService brewery)
        {
            Field(r => r.ReviewID);
            Field(r => r.ReviewDescription);
            Field(r => r.Rating);
            Field<UserType>("User",
                            resolve: context => users.Get(context.Source.UserID));
            Field<BreweryType>("Brewery",
                            resolve: context => brewery.Get(context.Source.BreweryID));
        }
    }
}