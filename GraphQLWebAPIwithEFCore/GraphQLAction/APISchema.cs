using System;
using Microsoft.Extensions.DependencyInjection;
using GraphQL.Types;

namespace GraphQLWebAPIwithEFCore.GraphQLAction
{
    public class APISchema : Schema
    {
        public APISchema(IServiceProvider serviceProvider)
            : base(serviceProvider)
        {
            this.Query = serviceProvider.GetRequiredService<RootQuery>();
        }
    }
}
