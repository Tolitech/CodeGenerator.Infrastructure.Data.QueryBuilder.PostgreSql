# Infrastructure.Data.QueryBuilder.PostgreSql
Infrastructure Data QueryBuilder PostgreSQL library used in projects created by the Code Generator tool. 

This project contains the implementation for using the Query Builder PostgreSQL. 

Tolitech Code Generator Tool: [http://www.tolitech.com.br](https://www.tolitech.com.br/)

Examples:
```
SqlBuilderConfiguration.UsePostgreSql();
```

```
var person = new PersonEntity()
{
    PersonId = 1,
    Name = "Person 1",
    Age = 18
};

string sql = new SqlBuilder()
    .Insert("public", "Person")
    .AddColumns(person)
    .Build();

string expected = "insert into \"public\".\"Person\" (\"PersonId\", \"Name\", \"Age\") values (@PersonId, @Name, @Age);";
```

```
var person = new PersonEntity()
{
    Name = "Person 1",
    Age = 18
};

string sql = new SqlBuilder()
    .Insert("Person")
    .AddColumns(person)
    .Identity("PersonId")
    .Build();

string expected = "insert into \"public\".\"Person\" (\"Name\", \"Age\") values (@Name, @Age) returning \"PersonId\";";
```

```
var person = new PersonEntity()
{
    PersonId = 1,
    Name = "Person 1",
    Age = 18
};

string sql = new SqlBuilder()
    .Update("public", "Person")
    .AddColumns(person)
    .RemoveColumn(nameof(person.PersonId))
    .Where()
    .AddColumn(nameof(person.PersonId))
    .Build();

string expected = "update \"public\".\"Person\" set \"Name\" = @Name, \"Age\" = @Age where \"PersonId\" = @PersonId;";
```

```
string sql = new SqlBuilder()
    .Delete("public", "Person")
    .Where()
    .AddColumn("PersonId")
    .AddCondition("and \"Age\" > @Age")
    .Build();

string expected = "delete from \"public\".\"Person\" where \"PersonId\" = @PersonId and \"Age\" > @Age;";
```

```
string sql = new SqlBuilder()
    .Select("dbo", "Person")
    .AddColumns("PersonId", "Name")
    .Where()
    .AddColumn("PersonId")
    .AddCondition("and \"Age\" > @Age")
    .Build();

string expected = "select \"PersonId\", \"Name\" from \"public\".\"Person\" where \"PersonId\" = @PersonId and \"Age\" > @Age;";
```