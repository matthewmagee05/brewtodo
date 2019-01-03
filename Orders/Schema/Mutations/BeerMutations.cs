using System;
using GraphQL;
using GraphQL.Types;
using Orders.Models;
using Orders.Schema.InputTypes;
using Orders.Services;

namespace Orders.Schema.Mutations
{
    public class BeerMutations: ObjectGraphType<object>
    {
        public BeerMutations(IBeerService beer)
        {
            Name="mutation";
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
        }
    }
}