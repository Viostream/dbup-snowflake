using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Odbc;
using System.Linq;
using DbUp.Engine.Output;
using DbUp.Engine.Transactions;

namespace DbUp.Snowflake
{
    public class SnowflakeConnectionFactory : IConnectionFactory
    {
        public string Database { get; }
        public string Warehouse { get; }

        public string ConnectionString { get; }
        public SnowflakeConnectionFactory(string connectionString)
        {
            var connection = connectionString.Split(';')
                .Where(x => !string.IsNullOrWhiteSpace(x))
                .Select(x =>
                {
                    var keyValue = x.Split('=');
                    return new KeyValuePair<string, string>(keyValue[0].ToLowerInvariant(), keyValue[1]);
                })
                .ToDictionary(x => x.Key, y => y.Value);

            if (!connection.ContainsKey("database"))
                throw new ArgumentException("Connection string does not have database parameter");
            if (!connection.ContainsKey("warehouse"))
                throw new ArgumentException("Connection string does not have warehouse parameter");

            ConnectionString = connectionString;
            Database = connection["database"];
            Warehouse = connection["warehouse"];
        }
        public IDbConnection CreateConnection(IUpgradeLog upgradeLog, DatabaseConnectionManager databaseConnectionManager)
        {
            var connection = new OdbcConnection(ConnectionString);
            connection.Open();
            var useWHcommand = new OdbcCommand($"use warehouse {Warehouse}", connection);
            useWHcommand.ExecuteNonQuery();
            var useDBcommand = new OdbcCommand($"use database {Database}", connection);
            useDBcommand.ExecuteScalar();
            return connection;
        }
    }
}
