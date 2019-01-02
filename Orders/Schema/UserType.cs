using System;
using GraphQL.Types;
using Orders.Models;
using Orders.Services;

namespace Orders.Schema
{
    public class UserType: ObjectGraphType<User>
    {
        public UserType(IUserBeerTriedService beers){
            Field(u => u.UserID);
            Field(u => u.IdentityID);
            Field(u => u.Username);
            Field(u => u.FirstName);
            Field(u => u.ProfileImage);
            Field<UserBeerTriedType>("UserBeersTried",
                                    resolve: context => beers.Get(context.Source.UserID));
        }

    }
}