using GraphQL.Types;

namespace Orders.Schema.InputTypes
{
    public class BeerInputType: InputObjectGraphType
    {
        public BeerInputType()
        {
            Name="BeerInput";
            Field<IntGraphType>("beerID");
            Field<NonNullGraphType<StringGraphType>>("beerName");
            Field<NonNullGraphType<StringGraphType>>("description");
            Field<NonNullGraphType<FloatGraphType>>("abv");
            Field<NonNullGraphType<IntGraphType>>("beerTypeId");
            Field<NonNullGraphType<IntGraphType>>("breweryId");
        }
    }
}