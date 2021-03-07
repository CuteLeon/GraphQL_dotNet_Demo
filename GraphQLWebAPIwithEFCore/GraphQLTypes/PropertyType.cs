using System.Linq;
using GraphQL;
using GraphQL.Types;
using GraphQLWebAPIwithEFCore.DataAccess;
using GraphQLWebAPIwithEFCore.Entity;

namespace GraphQLWebAPIwithEFCore.GraphQLTypes
{
    public class PropertyType : ObjectGraphType<Property>
    {
        public PropertyType(DatabaseContext dbContext)
        {
            this.Field(x => x.ID).Name("id");
            this.Field(x => x.City);
            this.Field(x => x.Value);
            this.Field(x => x.Owner);
            this.Field<ListGraphType<PaymentType>>("payments",
                arguments: new QueryArguments(new QueryArgument<IntGraphType> { Name = "count" }),
                resolve: context =>
                {
                    var count = context.GetArgument<int?>("count");
                    var result = dbContext.Payments.Where(x => x.PropertyID == context.Source.ID);
                    if (count.HasValue) result = result.TakeLast(count.Value);
                    return result;
                });
        }
    }
}
