using FluentMigrator;

namespace AspNetCoreNHibernate.FluentMigrator.Migrations
{
    [Migration(202201062311, "Inclusão das colunas 'Quantity', 'Price', 'Inserted' e 'Updated' na tabela Produtos")]
    public class AlterProductsTable : Migration
    {
        public override void Up()
        {
            Alter.Table("Products")
                .AddColumn("Quantity").AsInt32()
                .AddColumn("Price").AsDouble().NotNullable()
                .AddColumn("Inserted").AsDateTime()
                .AddColumn("Updated").AsDateTime().Nullable();
        }

        public override void Down()
        {
            IfDatabase("SqlServer", "MySql")
                .Delete.Column("Quantity")
                  .Column("Price")
                  .Column("Inserted")
                  .Column("Updated")
                  .FromTable("Products");

            IfDatabase("Sqlite")
              .Execute.Sql(
              @"ALTER TABLE Products DROP COLUMN Quantity;
                ALTER TABLE Products DROP COLUMN Price;
                ALTER TABLE Products DROP COLUMN Inserted;
                ALTER TABLE Products DROP COLUMN Updated;");
        }
    }
}
