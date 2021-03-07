using GraphQL.Types;
using GraphQLWebAPIwithEFCore.DataAccess;
using GraphQLWebAPIwithEFCore.Entity;

namespace GraphQLWebAPIwithEFCore.GraphQLTypes
{
    public class PaymentType : ObjectGraphType<Payment>
    {
        public PaymentType(DatabaseContext context)
        {
            this.Field(x => x.ID).Name("id");
            this.Field(x => x.Date);
            this.Field(x => x.HasPaid);
            this.Field(x => x.PropertyID);
            this.Field(x => x.Value);
        }
    }
}
