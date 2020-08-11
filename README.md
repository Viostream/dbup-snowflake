# DbUp Snowflake extensions

[![Nuget Package](https://img.shields.io/nuget/v/DbUp.Snowflake.svg?label=DbUp.Snowflake)](https://www.nuget.org/packages/DbUp.Snowflake/)
[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=Viostream_dbup-snowflake&metric=alert_status)](https://sonarcloud.io/dashboard?id=Viostream_dbup-snowflake)

Snowflake extentions for DbUp, distributed via [NuGet](https://www.nuget.org/packages/DbUp.Snowflake)

## Install

Use [Nuget](https://www.nuget.org/packages/DbUp.Snowflake/).

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
