using System.Collections.Generic;

namespace GraphQLWebAPIwithEFCore.GraphQLAction
{
    public class GraphQLQueryRequest
    {
        public string OperationName { get; set; }

        public string Query { get; set; }

        public Dictionary<string, object> Variables { get; set; }
    }
}
