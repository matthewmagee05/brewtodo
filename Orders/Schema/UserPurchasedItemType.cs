using System;
using GraphQL.Types;
using Orders.Models;
using Orders.Services;

namespace Orders.Schema
{
    public class UserPurchasedItemType: ObjectGraphType<UserPurchasedItem>
    {
        public UserPurchasedItemType(IUserService users, IBreweryService brewery)
        {
            Field(u => u.UserPurchasedItemID);
            Field<UserType>("User",
                            resolve: context => users.Get(context.Source.UserID));
            Field<BeerType>("Brewery",
                            resolve: context => brewery.Get(context.Source.BreweryID));
            Field(u => u.PurchasedTShirt);
            Field(u => u.PurchasedMug);
            Field(u => u.PurchasedGrowler);
            Field(u => u.TriedFood);
        }
    }
}