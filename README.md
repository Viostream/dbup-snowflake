# DbUp Snowflake extensions

[![Quality Gate Status](https://sonarcloud.io/api/project_badges/measure?project=Viostream_dbup-snowflake&metric=alert_status)](https://sonarcloud.io/dashboard?id=Viostream_dbup-snowflake)

Snowflake extentions for DbUp, distributed via [NuGet](https://www.nuget.org/packages/DbUp.Snowflake)

## Build and publish (for now)

1. Update `DbUp.Snowflake.nuspec` version and release notes
2. `dotnet build --configuration Release`
3. `nuget pack DbUp.Snowflake.nuspec`
4. Upload the `DbUp.Snowflake.0.0.x.nupkg` file to [NuGet](https://nuget.org)

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
