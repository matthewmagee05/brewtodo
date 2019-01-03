using GraphQL.Types;

namespace Orders.Schema.InputTypes
{
    public class BreweryCreateInputType: InputObjectGraphType
    {
        public BreweryCreateInputType()
        {
            Name = "BreweryInput";
            Field<IntGraphType>("breweryID");
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("description");
            Field<StringGraphType>("imageURL");
            Field<NonNullGraphType<StringGraphType>>("address");
            Field<NonNullGraphType<StringGraphType>>("zipCode");
            Field<NonNullGraphType<IntGraphType>>("stateId");
            Field<NonNullGraphType<StringGraphType>>("phoneNumber");
            Field<StringGraphType>("businessHours");
            Field<NonNullGraphType<BooleanGraphType>>("hasTShirt");
            Field<NonNullGraphType<BooleanGraphType>>("hasGrowler");
            Field<NonNullGraphType<BooleanGraphType>>("hasFood");
            Field<NonNullGraphType<BooleanGraphType>>("hasMug");
        }
    }
}