using System;
using System.Collections.Generic;
using System.Text;
using GraphQL.Types;
using GraphQLConsole.BusinessEntity;

namespace GraphQLConsole.GraphQLType
{
    public class PersonType : ObjectGraphType<Person>
    {
        public PersonType()
        {
            // Name for GraphQL, it's case sensitive
            this.Name = nameof(PersonType);
            this.Description = $"{nameof(PersonType)} for GraphQL.";
            this.Field(x => x.ID).Description("编号").DefaultValue(-1).Name(nameof(Person.ID));
            this.Field(x => x.Name).Description("名称").DefaultValue("Leon").Name(nameof(Person.Name));
        }
    }
}
