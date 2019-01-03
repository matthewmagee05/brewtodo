using System;
using GraphQL;
using GraphQL.Types;
using Orders.Models;
using Orders.Schema.InputTypes;
using Orders.Services;

namespace Orders.Schema.Mutations
{
    public class ReviewMutation: ObjectGraphType<object>
    {
        public ReviewMutation(IReviewService reviews)
        {
            Name="mutation";
            Field<ReviewType>(
                "createdReview",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ReviewInputType>>{Name = "review"}
                ),
                resolve: context => {
                    var reviewInput = context.GetArgument<Review>("review");
                    return reviews.Post(reviewInput);
                }
            );
            Field<ReviewType>(
                "deletedReview",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ReviewInputType>>{Name = "review"}
                ),
                resolve: context => {
                    var reviewInput = context.GetArgument<Review>("review");
                    return reviews.Delete(reviewInput.ReviewID);
                }
            );
            Field<ReviewType>(
                "updatedReview",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<ReviewInputType>>{Name = "review"}
                ),
                resolve: context => {
                    var reviewInput = context.GetArgument<Review>("review");
                    return reviews.Put(reviewInput);
                }
            );
        }
    }
}