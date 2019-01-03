using System;
using GraphQL;
using GraphQL.Types;
using Orders.Models;
using Orders.Schema.InputTypes;
using Orders.Services;

namespace Orders.Schema.Mutations
{
    public class BeerTypeMutation: ObjectGraphType<object>
    {
        public BeerTypeMutation(IBeerTypeService beerType)
        {
            Name="mutation";
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
        }
    }
}