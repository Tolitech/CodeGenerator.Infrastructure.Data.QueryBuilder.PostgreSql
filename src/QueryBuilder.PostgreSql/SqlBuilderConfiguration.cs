using System;

namespace Tolitech.CodeGenerator.Infrastructure.Data.QueryBuilder.PostgreSql
{
    public class SqlBuilderConfiguration
    {
        public static void UsePostgreSql()
        {
            AddQueryBuilder("default");
        }

        public static void AddQueryBuilder(string key)
        {
            var builderFactory = new PostgreSqlBuilderFactory();
            SqlBuilder.AddQueryBuilder(key, builderFactory);
        }
    }
}
