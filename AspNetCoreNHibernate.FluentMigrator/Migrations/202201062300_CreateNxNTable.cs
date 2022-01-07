using FluentMigrator;

namespace AspNetCoreNHibernate.FluentMigrator.Migrations
{
    [Migration(202201062300, "Criação da tabela 'SuppliersProducts' para relacionamento NxN entre Fornecedores e Produtos")]
    public class CreateNxNTable : Migration
    {
        public override void Up()
        {
            Create.Table("SuppliersProducts")
                .WithColumn("Product_id").AsInt64().NotNullable()
                .WithColumn("Supplier_id").AsInt64().NotNullable();

            Create.PrimaryKey()
                .OnTable("SuppliersProducts")
                .Columns("Product_id", "Supplier_id");

            Create.ForeignKey()
                .FromTable("SuppliersProducts").ForeignColumn("Product_id")
                .ToTable("Products").PrimaryColumn("Id");

            Create.ForeignKey()
                .FromTable("SuppliersProducts").ForeignColumn("Supplier_id")
                .ToTable("Suppliers").PrimaryColumn("Id");
        }

        public override void Down()
        {
            Delete.ForeignKey()
                .FromTable("SuppliersProducts").ForeignColumn("Product_id")
                .ToTable("Products").PrimaryColumn("Id");

            Delete.ForeignKey()
                .FromTable("SuppliersProducts").ForeignColumn("Supplier_id")
                .ToTable("Suppliers").PrimaryColumn("Id");

            Delete.Table("SuppliersProducts");
        }
    }
}
