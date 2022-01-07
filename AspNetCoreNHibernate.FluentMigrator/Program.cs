using AspNetCoreNHibernate.FluentMigrator.Migrations;
using FluentMigrator.Runner;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AspNetCoreNHibernate.FluentMigrator
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = CreateServices();

            using var scope = serviceProvider.CreateScope();
            UpdateDatabase(scope.ServiceProvider);
        }

        static IServiceProvider CreateServices()
        {
            var connectionString = $"Data Source={AppContext.BaseDirectory}\\..\\..\\..\\StoreMigrator.db";

            return new ServiceCollection()
                .AddFluentMigratorCore()
                .ConfigureRunner(runner =>
                {
                    runner.AddSQLite()
                        .WithGlobalConnectionString(connectionString)
                        .ScanIn(typeof(CreateCategoryTable).Assembly).For.Migrations();
                })
                .AddLogging(logger => logger.AddFluentMigratorConsole())
                .Configure<FluentMigratorLoggerOptions>(option =>
                {
                    option.ShowSql = true;
                    option.ShowElapsedTime = true;
                })
                .BuildServiceProvider(false);
        }

        static void UpdateDatabase(IServiceProvider serviceProvider)
        {
            var runner = serviceProvider.GetRequiredService<IMigrationRunner>();
            
            if (runner.HasMigrationsToApplyUp())
            {
                runner.MigrateUp();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Não há migrações pendentes para execução");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}
