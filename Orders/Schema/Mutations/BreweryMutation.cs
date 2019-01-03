using System;
using GraphQL;
using GraphQL.Types;
using Orders.Models;
using Orders.Schema.InputTypes;
using Orders.Services;

namespace Orders.Schema.Mutations
{
    public class BreweryMutation: ObjectGraphType<object>
    {
        public BreweryMutation(
                IBreweryService brewery,
                IBeerService beer,
                IBeerTypeService beerType,
                IReviewService reviews,
                IUserBeerTriedService usb,
                IUserService users,
                IUserPurchasedItemService upi
            )
        {
            Name="mutation";
            Field<BreweryType>(
                "createdBrewery",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<BreweryCreateInputType>>{Name = "brewery"}
                ),
                resolve: context => {
                    var breweryInput = context.GetArgument<Brewery>("brewery");
                    return brewery.Post(breweryInput);
                }
            );
            Field<BreweryType>(
                "deletedBrewery",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<BreweryCreateInputType>>{Name = "brewery"}
                ),
                resolve: context => {
                    var breweryInput = context.GetArgument<Brewery>("brewery");
                    return brewery.Delete(breweryInput.BreweryID);
                }
            );
            Field<BreweryType>(
                "updatedBrewery",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<BreweryCreateInputType>>{Name = "brewery"}
                ),
                resolve: context => {
                    var breweryInput = context.GetArgument<Brewery>("brewery");
                    return brewery.Put(breweryInput);
                }
            );
            Field<BeerType>(
                "createdBeer",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<BeerInputType>>{Name = "beer"}
                ),
                resolve: context => {
                    var beerInput = context.GetArgument<Beer>("beer");
                    return beer.Post(beerInput);
                }
            );
            Field<BeerType>(
                "deletedBeer",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<BeerInputType>>{Name = "beer"}
                ),
                resolve: context => {
                    var beerInput = context.GetArgument<Beer>("beer");
                    return beer.Delete(beerInput.BeerID);
                }
            );
            Field<BeerType>(
                "updatedBeer",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<BeerInputType>>{Name = "beer"}
                ),
                resolve: context => {
                    var beerInput = context.GetArgument<Beer>("beer");
                    return beer.Put(beerInput);
                }
            );
            Field<BeerTypeType>(
                "createdBeerType",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<BeerTypeInputType>>{Name = "beerType"}
                ),
                resolve: context => {
                    var beerTypeInput = context.GetArgument<Models.BeerType>("beerType");
                    return beerType.Post(beerTypeInput);
                }
            );
            Field<BeerTypeType>(
                "deletedBeerType",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<BeerTypeInputType>>{Name = "beerType"}
                ),
                resolve: context => {
                    var beerTypeInput = context.GetArgument<Models.BeerType>("beerType");
                    return beerType.Delete(beerTypeInput.BeerTypeID);
                }
            );
            Field<BeerTypeType>(
                "updatedBeerType",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<BeerTypeInputType>>{Name = "beerType"}
                ),
                resolve: context => {
                    var beerTypeInput = context.GetArgument<Models.BeerType>("beer");
                    return beerType.Put(beerTypeInput);
                }
            );
            Field<ReviewType>(
                "createdReview",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ReviewInputType>>{Name = "review"}
                ),
                resolve: context => {
                    var reviewInput = context.GetArgument<Review>("review");
                    return reviews.Post(reviewInput);
                }
            );
            Field<ReviewType>(
                "deletedReview",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ReviewInputType>>{Name = "review"}
                ),
                resolve: context => {
                    var reviewInput = context.GetArgument<Review>("review");
                    return reviews.Delete(reviewInput.ReviewID);
                }
            );
            Field<ReviewType>(
                "updatedReview",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ReviewInputType>>{Name = "review"}
                ),
                resolve: context => {
                    var reviewInput = context.GetArgument<Review>("review");
                    return reviews.Put(reviewInput);
                }
            );
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
                "updatedUserPurchasedItem",
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