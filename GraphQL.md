# GraphQL

> https://graphql.cn/
>
> https://graphql.cn/learn/
>
> https://github.com/graphql-dotnet/graphql-dotnet
>
> https://graphql-dotnet.github.io/

一种用于 API 的查询语言。GraphQL 既是一种用于 API 的查询语言也是一个满足你数据查询的运行时。 GraphQL 对你的 API 中的数据提供了一套易于理解的完整描述，使得客户端能够准确地获得它需要的数据，而且没有任何冗余，也让 API 更容易地随着时间推移而演进，还能用于构建强大的开发者工具。

## Term

- GraphType: GraphQL中的类型，包含GraphQL核心规范中定义的类型和自定义数据
- Query: 操作类型之一，用于数据查询
- Mutation: 操作类型之一，用于数据修改
- Subscription: 操作类型之一，用于数据推送
- Schema: 结构定义

## 控制台实现

### 安装依赖包

```
Install-Package GraphQL
Install-Package GraphQL.SystemTextJson
```

## 设计业务模型类

```csharp
public class Person
{
	public int ID { get; set; }

	public string Name { get; set; }
}
```

## 实现业务模型对应的GraphQL类型

```csharp
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
```

## 实现GraphQL查询模型

```csharp
public class PersonQuery : ObjectGraphType
{
    public const string QueryName = "QueryPerson";

    public PersonQuery()
    {
        this.Name = nameof(PersonQuery);
        this.Description = $"{nameof(PersonQuery)} for GraphQL.";
        this.Field<PersonType>(QueryName, resolve: context => new Person() { ID = 001, Name = "CuteLeon" });
    }
}
```

## 使用Schema查询

```csharp
Schema schema = new Schema { Query = new PersonQuery { } };
var jsonResult = await schema.ExecuteAsync(default, options =>
{
	options.Query = "{QueryPerson{ID, NAME}}";
});
Console.WriteLine(jsonResult);
```

