using System;
using GraphQL;
using GraphQL.Types;
using Orders.Models;
using Orders.Schema.InputTypes;
using Orders.Services;

namespace Orders.Schema.Mutations
{
    public class UserPurchasedItemMutation: ObjectGraphType<object>
    {
        public UserPurchasedItemMutation(UserPurchasedItemService upi)
        {
            Name="mutation";
            Field<UserPurchasedItemType>(
                "createdUserPurchasedItem",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserPurchasedItemInputType>>{Name = "userPurchasedItem"}
                ),
                resolve: context => {
                    var userInput = context.GetArgument<UserPurchasedItem>("userPurchasedItem");
                    return upi.Post(userInput);
                }
            );
            Field<UserPurchasedItemType>(
                "deletedUserPurchasedItem",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserPurchasedItemInputType>>{Name = "userPurchasedItem"}
                ),
                resolve: context => {
                    var userInput = context.GetArgument<UserPurchasedItem>("userPurchasedItem");
                    return upi.Delete(userInput.UserPurchasedItemID);
                }
            );
            Field<UserPurchasedItemType>(
                "updatedUser",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserPurchasedItemInputType>>{Name = "userPurchasedItem"}
                ),
                resolve: context => {
                    var userInput = context.GetArgument<UserPurchasedItem>("user");
                    return upi.Put(userInput);
                }
            );
        }
    }
}