using GraphQL.Types;

namespace GraphQLWebAPIwithEFCore.GraphQLTypes
{
    public class PropertyInputType : InputObjectGraphType
    {
        public PropertyInputType()
        {
            this.Field<NonNullGraphType<StringGraphType>>("city");
            this.Field<NonNullGraphType<StringGraphType>>("owner");
            this.Field<DecimalGraphType>("value");
        }
    }
}
