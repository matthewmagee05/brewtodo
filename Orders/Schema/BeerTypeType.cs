using System;
using GraphQL.Types;
using Orders.Models;

namespace Orders.Schema
{
    public class BeerTypeType: ObjectGraphType<Models.BeerType>
    {
         public BeerTypeType()
        {
            Field(b => b.BeerTypeID);
            Field(b => b.BeerTypeName);
        }
    }
}