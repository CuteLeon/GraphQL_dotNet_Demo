using System.Linq;
using GraphQL;
using GraphQL.Types;
using GraphQLWebAPIwithEFCore.DataAccess;
using GraphQLWebAPIwithEFCore.GraphQLTypes;

namespace GraphQLWebAPIwithEFCore.GraphQLAction
{
    public class PropertyQuery : ObjectGraphType
    {
        public PropertyQuery(DatabaseContext dbContext)
        {
            this.Field<ListGraphType<PropertyType>>("properties", resolve: context => dbContext.Properties.AsEnumerable());

            this.Field<PropertyType>("property",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "id" }),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return dbContext.Properties.Find(id);
                });
        }
    }
}
