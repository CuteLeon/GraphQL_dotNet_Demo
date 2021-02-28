using System;
using System.Threading.Tasks;
using GraphQL;
using GraphQL.Types;
using GraphQL.SystemTextJson;
using GraphQLConsole.GraphQLQuery;

namespace GraphQLConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Schema schema = new Schema { Query = new PersonQuery { } };
            var jsonResult = await schema.ExecuteAsync(new DocumentWriter(), options =>
             {
                 // schema 使用驼峰命名规范
                 options.Query = "{queryPerson{iD, name}}";

             });
            Console.WriteLine(jsonResult);
            Console.Read();
        }
    }
}
