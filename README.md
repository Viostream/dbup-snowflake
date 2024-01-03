# DbUp Snowflake extensions

[![Nuget Package](https://img.shields.io/nuget/v/B3zaleel.DbUp.Snowflake.svg?label=B3zaleel.DbUp.Snowflake)](https://www.nuget.org/packages/B3zaleel.DbUp.Snowflake/)

Snowflake extensions for DbUp, distributed via [NuGet](https://www.nuget.org/packages/B3zaleel.DbUp.Snowflake)

## Install

Use [Nuget](https://www.nuget.org/packages/B3zaleel.DbUp.Snowflake/).

## Use

```csharp
...

using DbUp.Snowflake;

namespace MyNamespace
{
    class Program
    {
        static int Main(string[] args)
        {
            ...
            var connectionString = "getThisFromSomewhereSecret";
            var upgrader =
                DeployChanges.To
                    .SnowflakeDatabase($"DSN=snowflake;{connectionString}", "JOURNAL_SCHEMA")
                    .WithScriptsEmbeddedInAssembly(Assembly.GetExecutingAssembly())
                    .LogToConsole()
                    .Build();

            var result = upgrader.PerformUpgrade();
            ...
        }
    }
}
```
