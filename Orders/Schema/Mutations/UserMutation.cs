using System;
using GraphQL;
using GraphQL.Types;
using Orders.Models;
using Orders.Schema.InputTypes;
using Orders.Services;

namespace Orders.Schema.Mutations
{
    public class UserMutation: ObjectGraphType<object>
    {
        public UserMutation(IUserService users)
        {
            Name="mutation";
            Field<UserType>(
                "createdUser",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserInputType>>{Name = "user"}
                ),
                resolve: context => {
                    var userInput = context.GetArgument<User>("user");
                    return users.Post(userInput);
                }
            );
            Field<UserType>(
                "deletedUser",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserInputType>>{Name = "user"}
                ),
                resolve: context => {
                    var userInput = context.GetArgument<User>("user");
                    return users.Delete(userInput.UserID);
                }
            );
            Field<UserType>(
                "updatedUser",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<UserInputType>>{Name = "user"}
                ),
                resolve: context => {
                    var userInput = context.GetArgument<User>("user");
                    return users.Put(userInput);
                }
            );
        }
    }
}