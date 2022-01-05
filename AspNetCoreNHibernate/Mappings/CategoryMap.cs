using AspNetCoreNHibernate.Models;

namespace AspNetCoreNHibernate.Mappings
{
    public class CategoryMap : BaseEntityMapping<Category>
    {
        public CategoryMap()
        {
            Table("Categories");

            HasMany(x => x.Products)
                .Table("Products")
                .ForeignKeyConstraintName("[FK_Products.Category]")
                .Inverse() // stop auto updating products table
                .KeyColumn("[CategoryId]"); // will be created at Products Table
        }
    }
}
