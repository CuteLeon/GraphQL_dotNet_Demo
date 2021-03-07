using System.Linq;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQLWebAPIwithEFCore.DataAccess;
using GraphQLWebAPIwithEFCore.GraphQLAction;
using Microsoft.AspNetCore.Mvc;

namespace GraphQLWebAPIwithEFCore.Controllers
{
    [ApiController]
    public class GraphQLController : Controller
    {
        private readonly DatabaseContext context;
        private readonly ISchema schema;
        private readonly IDocumentExecuter documentExecuter;

        public GraphQLController(
            DatabaseContext context,
            ISchema schema,
            IDocumentExecuter documentExecuter)
        {
            this.context = context;
            this.schema = schema;
            this.documentExecuter = documentExecuter;
        }

        [HttpPost]
        [Route("GraphQL/Query")]
        public async Task<IActionResult> Query([FromBody] GraphQLQueryRequest query)
        {
            if (query is null || string.IsNullOrWhiteSpace(query.Query))
            {
                throw new System.ArgumentNullException(nameof(query));
            }

            var inputs = query.Variables.ToInputs();
            var executionOptions = new ExecutionOptions
            {
                Schema = schema,
                Query = query.Query,
                Inputs = inputs,
            };
            var result = await this.documentExecuter.ExecuteAsync(executionOptions);
            return result.Errors?.Any() ?? false ?
                this.BadRequest(result.Errors) :
                this.Ok(result.Data);
        }
    }
}
