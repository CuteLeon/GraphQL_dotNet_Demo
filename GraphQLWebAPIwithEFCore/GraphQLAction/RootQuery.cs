using System.Linq;
using GraphQL;
using GraphQL.Types;
using GraphQLWebAPIwithEFCore.DataAccess;
using GraphQLWebAPIwithEFCore.GraphQLTypes;

namespace GraphQLWebAPIwithEFCore.GraphQLAction
{
    public class RootQuery : ObjectGraphType
    {
        public RootQuery(DatabaseContext dbContext)
        {
            this.Field<ListGraphType<PropertyType>>("properties",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int?>("id");
                    return id.HasValue ?
                        dbContext.Properties.Find(id.Value) :
                        dbContext.Properties.ToList();
                });
        }
    }
}
