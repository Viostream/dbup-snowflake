using System.Collections.Generic;
using DbUp.Engine;

namespace DbUp.Snowflake
{
    public class SnowflakePreprocessor : IScriptPreprocessor
    {
        public IDictionary<string, string> Variables { get; }

        public SnowflakePreprocessor(IDictionary<string, string> variables)
        {
            Variables = variables;
        }

        public string Process(string contents)
        {
            foreach (var variable in Variables.Keys)
            {
                var token = "{{" + variable + "}}";
                contents = contents.Replace(token, Variables[variable]);
            }
            return contents;
        }
    }
}
