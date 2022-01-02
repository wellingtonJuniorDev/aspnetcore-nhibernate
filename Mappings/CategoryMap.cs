using AspNetCoreNHibernate.Models;
using FluentNHibernate.Mapping;

namespace AspNetCoreNHibernate.Mappings
{
    public class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table("Categories");

            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.Name).Not.Nullable().Length(50);

            HasMany(x => x.Products)
                .Table("Products")
                .ForeignKeyConstraintName("[FK_Products.Category]")
                .Inverse() // stop auto updating products table
                .KeyColumn("[CategoryId]"); // will be created at Products Table
        }
    }
}
