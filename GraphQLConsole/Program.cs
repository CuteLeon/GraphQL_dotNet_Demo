using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQLConsole.GraphQLQuery;

namespace GraphQLConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Schema schema = new Schema { Query = new PersonQuery { } };
            var jsonResult = await schema.ExecuteAsync(default, options =>
             {
                 options.Query = "{QueryPerson{ID, NAME}}";

             });
            Console.WriteLine(jsonResult);
            Console.Read();
        }
    }
}
