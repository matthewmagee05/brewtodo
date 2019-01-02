using System;
using GraphQL.Types;
using Orders.Models;
using Orders.Services;

namespace Orders.Schema
{
    public class UserBeerTriedType: ObjectGraphType<UserBeerTried>
    {
        public UserBeerTriedType(IUserService users, IBeerService beers)
        {
            Field(u => u.UserBeerTriedID);
            Field<UserType>("User",
                            resolve: context => users.Get(context.Source.UserID));
            Field<BeerType>("Beer",
                            resolve: context => beers.Get(context.Source.BeerID));
        }

    }
}