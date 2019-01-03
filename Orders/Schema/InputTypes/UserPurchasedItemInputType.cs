using GraphQL.Types;

namespace Orders.Schema.InputTypes
{
    public class UserPurchasedItemInputType: InputObjectGraphType
    {
        public UserPurchasedItemInputType(){
            Name="UserPurchasedItemInput";
            Field<IntGraphType>("userPurchasedItemID");
            Field<NonNullGraphType<IntGraphType>>("userId");
            Field<NonNullGraphType<IntGraphType>>("breweryId");
            Field<NonNullGraphType<BooleanGraphType>>("purchasedTShirt");
            Field<NonNullGraphType<BooleanGraphType>>("purchasedMug");
            Field<NonNullGraphType<BooleanGraphType>>("purchasedGrowler");
            Field<NonNullGraphType<BooleanGraphType>>("triedFood");
        }
    }
}