using GraphQL;
using Orders.Schema.Mutations;
using System;

namespace Orders.Schema
{
    public class BrewerySchema: GraphQL.Types.Schema
    {
        public BrewerySchema(BreweryQuery query, IDependencyResolver resolver, BreweryMutation mutation)
        {
            Query = query;
            Mutation = mutation;
            DependencyResolver = resolver;
        }

    }
}