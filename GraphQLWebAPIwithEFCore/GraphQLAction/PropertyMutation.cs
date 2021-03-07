using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQLWebAPIwithEFCore.DataAccess;
using GraphQLWebAPIwithEFCore.Entity;
using GraphQLWebAPIwithEFCore.GraphQLTypes;

namespace GraphQLWebAPIwithEFCore.GraphQLAction
{
    public class PropertyMutation : ObjectGraphType
    {
        public PropertyMutation(DatabaseContext dbContext)
        {
            this.Field<PropertyType>("addProperty",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<PropertyInputType>> { Name = "propertyDetail" }),
                resolve: context =>
                {
                    var propertyDetail = context.GetArgument<Property>("propertyDetail");
                    var record = dbContext.Properties.Add(propertyDetail);
                    dbContext.SaveChanges();
                    return record;
                });
        }
    }
}
