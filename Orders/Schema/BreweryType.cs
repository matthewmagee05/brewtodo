using GraphQL.Types;
using Orders.Models;
using Orders.Services;

namespace Orders.Schema
{
    public class BreweryType: ObjectGraphType<Brewery>
    {
        public BreweryType(IReviewService review, IBeerService beer, IUserService user)
        {
            Field(b => b.BreweryID);
            Field(b => b.Name);
            Field(b => b.Description);
            Field(b => b.ImageURL);
            Field(b => b.Address);
            Field(b => b.ZipCode);
            Field(b => b.StateID);
            Field(b => b.PhoneNumber);
            Field(b => b.BusinessHours);
            Field(b => b.HasTShirt);
            Field(b => b.HasGrowler);
            Field(b => b.HasFood);
            Field(b => b.HasMug);
            Field<ListGraphType<ReviewType>>("review",
                            resolve: context => review.GetAllReviewsById(context.Source.BreweryID));
            Field<ListGraphType<BeerType>>("beer",
                            resolve: context => beer.GetAllBeersById(context.Source.BreweryID));
        }
    }
}
