using FluentMigrator;

namespace AspNetCoreNHibernate.FluentMigrator.Migrations
{
    [Migration(202201062227, "Criação da tabela de produtos e relacionamento com Categoria")]
    public class CreateProductsTable : Migration
    {
        public override void Up()
        {
            Create.Table("Products")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("CategoryId").AsInt64();

            Create.ForeignKey()
                .FromTable("Products").ForeignColumn("CategoryId")
                .ToTable("Categories").PrimaryColumn("Id");
        }

        public override void Down()
        {
            Delete.ForeignKey()
                .FromTable("Products").ForeignColumn("CategoryId")
                .ToTable("Categories").PrimaryColumn("Id");

            Delete.Table("Products");
        }
    }
}
