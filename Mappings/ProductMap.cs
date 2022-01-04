using AspNetCoreNHibernate.Models;

namespace AspNetCoreNHibernate.Mappings
{
    public class ProductMap : BaseEntityMapping<Product>
    {
        public ProductMap()
        {
            Table("Products");

            Map(b => b.Quantity).Not.Nullable();
            Map(b => b.Price).Nullable().Scale(2).Precision(5);

            Component(b => b.Audit);
            
            References(b => b.Category)
                .Columns("[CategoryId]"); // will be created at Products Table
        }
    }
}
