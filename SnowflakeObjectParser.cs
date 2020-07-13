using DbUp.Support;

namespace DbUp.Snowflake
{
    /// <summary>
    /// Parses Sql Objects and performs quoting functions
    /// </summary>
    public class SnowflakeObjectParser : SqlObjectParser
    {
        public SnowflakeObjectParser() : base("\"", "\"")
        {
        }
    }
}
