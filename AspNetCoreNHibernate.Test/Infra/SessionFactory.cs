using AspNetCoreNHibernate.Models;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using System;

namespace AspNetCoreNHibernate.Test.Infra
{
    public static class SessionFactory
    {
        public static ISessionFactory Build()
        {
            var configuration = new Configuration();
            configuration.DataBaseIntegration(c =>
            {
                c.KeywordsAutoImport = Hbm2DDLKeyWords.AutoQuote;
                c.SchemaAction = SchemaAutoAction.Update;
                c.LogFormattedSql = true;
                c.LogSqlInConsole = true;
            });

            var testConnectionString = $"Data Source={AppContext.BaseDirectory}\\..\\..\\..\\TestNHibernate.db";

            return Fluently.Configure(configuration)
                .Database(SQLiteConfiguration.Standard.ConnectionString(testConnectionString))
                .Mappings(m => m.FluentMappings.AddFromAssemblyOf<BaseEntity>())
                .BuildSessionFactory();
        }
    }
}
