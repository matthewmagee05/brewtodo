using GraphQL.Types;
namespace Orders.Schema.InputTypes
{
    public class UserBeerTriedInputType: InputObjectGraphType
    {
        public UserBeerTriedInputType(){
            Name="UserBeerTriedInput";
            Field<IntGraphType>("userBeerTriedID");
            Field<NonNullGraphType<IntGraphType>>("userId");
            Field<NonNullGraphType<IntGraphType>>("beerId");
        }
    }
}