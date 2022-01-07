using FluentMigrator;

namespace AspNetCoreNHibernate.FluentMigrator.Migrations
{
    [Migration(202201062249, "Criação da tabela de Fornecedores e de Empresas")]
    public class CreateSupplierAndCompanyTables : Migration
    {
        public override void Up()
        {
            Create.Table("Suppliers")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable();

            Create.Table("Companies")
                .WithColumn("Id").AsInt64().PrimaryKey().Identity()
                .WithColumn("Name").AsString(50).NotNullable()
                .WithColumn("SupplierId").AsInt64().NotNullable();

            Create.ForeignKey()
                .FromTable("Companies").ForeignColumn("SupplierId")
                .ToTable("Suppliers").PrimaryColumn("Id");
        }

        public override void Down()
        {
            Delete.ForeignKey()
                .FromTable("Companies").ForeignColumn("SupplierId")
                .ToTable("Suppliers").PrimaryColumn("Id");

            Delete.Table("Companies");
            Delete.Table("Suppliers");
        }        
    }
}
