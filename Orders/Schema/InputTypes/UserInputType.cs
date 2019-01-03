using GraphQL.Types;

namespace Orders.Schema.InputTypes
{
    public class UserInputType: InputObjectGraphType
    {
        public UserInputType()
        {
            Name="UserInput";
            Field<IntGraphType>("userID");
            Field<NonNullGraphType<IntGraphType>>("identityId");
            Field<NonNullGraphType<StringGraphType>>("username");
            Field<NonNullGraphType<StringGraphType>>("firstName");
            Field<NonNullGraphType<StringGraphType>>("lastName");
            Field<NonNullGraphType<IntGraphType>>("profileImage");
        }
    }
}