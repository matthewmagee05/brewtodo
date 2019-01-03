using GraphQL.Types;
namespace Orders.Schema.InputTypes
{
    public class ReviewInputType: InputObjectGraphType
    {
         public ReviewInputType()
        {
            Name="ReviewInput";
            Field<IntGraphType>("reviewID");
            Field<NonNullGraphType<StringGraphType>>("reviewDescription");
            Field<NonNullGraphType<FloatGraphType>>("rating");
            Field<NonNullGraphType<IntGraphType>>("userId");
            Field<NonNullGraphType<IntGraphType>>("breweryId");
        }

    }
}