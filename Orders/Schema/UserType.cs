using System;
using GraphQL.Types;
using Orders.Models;
using Orders.Services;

namespace Orders.Schema
{
    public class UserType: ObjectGraphType<User>
    {
        public UserType(IUserBeerTriedService beers, IUserPurchasedItemService items){
            Field(u => u.UserID);
            Field(u => u.IdentityID);
            Field(u => u.Username);
            Field(u => u.FirstName);
            Field(u => u.ProfileImage);
            Field<ListGraphType<UserBeerTriedType>>("UserBeersTried",
                                    resolve: context => beers.Get(context.Source.UserID));
            Field<ListGraphType<UserPurchasedItemType>>("UserPurchasedItem",
                                    resolve: context => items.Get(context.Source.UserID));
        }

    }
}