using System;
using System.Collections.Generic;
using System.Data.Odbc;
using DbUp.Engine;
using DbUp.Engine.Output;
using DbUp.Engine.Transactions;
using DbUp.Support;

namespace DbUp.Snowflake
{
    public class SnowflakeScriptExecutor : ScriptExecutor
    {
        public SnowflakeScriptExecutor(Func<IConnectionManager> connectionManagerFactory, Func<IUpgradeLog> log, string schema, Func<bool> variablesEnabled, List<IScriptPreprocessor> scriptPreprocessors,
                                       Func<IJournal> journal)
            : base(connectionManagerFactory, new SnowflakeObjectParser(), log, schema, variablesEnabled, scriptPreprocessors, journal)
        { }

        protected override string GetVerifySchemaSql(string schema)
        {
            return $@"CREATE SCHEMA IF NOT EXISTS {schema}";
        }

        protected override void ExecuteCommandsWithinExceptionHandler(int index, SqlScript script, Action executeCallback)
        {
            try
            {
                executeCallback();
            }
            catch (OdbcException ex)
            {
                Log().WriteInformation("Snowflake exception has occured in script: '{0}'", script.Name);
                Log().WriteError(ex.ToString());
                throw;
            }
        }
    }
}
