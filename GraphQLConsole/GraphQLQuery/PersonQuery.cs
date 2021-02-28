using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;
using GraphQLConsole.BusinessEntity;
using GraphQLConsole.GraphQLType;

namespace GraphQLConsole.GraphQLQuery
{
    public class PersonQuery : ObjectGraphType
    {
        public PersonQuery()
        {
            this.Name = nameof(PersonQuery);
            this.Description = $"{nameof(PersonQuery)} for GraphQL.";
            this.Field<PersonType>("queryPerson", resolve: context => new Person() { ID = 001, Name = "CuteLeon" });
        }
    }
}
