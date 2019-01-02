
using System;
using GraphQL.Types;
using Orders.Models;
using Orders.Services;

namespace Orders.Schema
{
    public class BeerType: ObjectGraphType<Beer>
    {
        public BeerType(IBeerTypeService beers, IBreweryService breweries)
            {
                Field(b => b.BeerID);
                Field(b => b.BeerName);
                Field(b => b.Description);
                Field(b => b.ABV);
                Field<BeerTypeType>("BeerType",
                                    resolve: context => beers.Get(context.Source.BeerID));
                Field<BreweryType>("Brewery",
                                    resolve: context => breweries.Get(context.Source.BreweryID));

            }
    }
}