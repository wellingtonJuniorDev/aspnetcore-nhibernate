using AspNetCoreNHibernate.Models;

namespace AspNetCoreNHibernate.Mappings
{
    public class SupplierMap : BaseEntityMapping<Supplier>
    {
        public SupplierMap()
        {
            Table("Suppliers");

            HasOne(x => x.Company).Cascade.All();

            HasManyToMany(x => x.Products)
                .Table("[SuppliersProducts]");
        }
    }
}
