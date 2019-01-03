using System;
using GraphQL;
using GraphQL.Types;
using Orders.Models;
using Orders.Schema.InputTypes;
using Orders.Services;

namespace Orders.Schema.Mutations
{
    public class UserBeerTriedMutation: ObjectGraphType<object>
    {
        public UserBeerTriedMutation(IUserBeerTriedService usb)
        {
            Name="mutation";
            Field<UserBeerTriedType>(
                "createdUserBeerTried",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserBeerTriedInputType>>{Name = "userBeerTried"}
                ),
                resolve: context => {
                    var userBeerTriedInput = context.GetArgument<UserBeerTried>("userBeerTried");
                    return usb.Post(userBeerTriedInput);
                }
            );
            Field<UserBeerTriedType>(
                "deletedUserBeerTried",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserBeerTriedInputType>>{Name = "userBeerTried"}
                ),
                resolve: context => {
                    var userBeerTriedInput = context.GetArgument<UserBeerTried>("userBeerTried");
                    return usb.Delete(userBeerTriedInput.UserBeerTriedID);
                }
            );
            Field<UserBeerTriedType>(
                "updatedUserBeerTried",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserBeerTriedInputType>>{Name = "userBeerTried"}
                ),
                resolve: context => {
                    var userBeerTriedInput = context.GetArgument<UserBeerTried>("userBeerTried");
                    return usb.Put(userBeerTriedInput);
                }
            );
        }
    }
}