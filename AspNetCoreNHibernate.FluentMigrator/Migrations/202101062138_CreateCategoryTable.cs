using FluentMigrator;

namespace AspNetCoreNHibernate.FluentMigrator.Migrations
{
    [Migration(202101062138)]
    public class CreateCategoryTable : Migration
    {
        public override void Up()
        {
            Create.Table("Categories")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable();
        }

        public override void Down() => Delete.Table("Categories");
    }
}
