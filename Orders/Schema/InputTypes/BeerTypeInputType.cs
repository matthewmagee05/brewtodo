using GraphQL.Types;

namespace Orders.Schema.InputTypes
{
    public class BeerTypeInputType: InputObjectGraphType
    {
         public BeerTypeInputType()
        {
            Name="BeerTypeInput";
            Field<IntGraphType>("beerTypeID");
            Field<NonNullGraphType<StringGraphType>>("beerTypeName");
        }
    }
}