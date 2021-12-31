using AspNetCoreNHibernate.Models;
using FluentNHibernate.Mapping;

namespace AspNetCoreNHibernate.Mappings
{
    public class ProductMap : ClassMap<Product>
    {
        public ProductMap()
        {
            Table("Products");

            Id(b => b.Id).GeneratedBy.Identity();

            Map(b => b.Name).Not.Nullable().Length(520);

            Map(b => b.Quantity).Not.Nullable();

            Map(b => b.Price).Nullable().Scale(2).Precision(5);

            Component(b => b.Audit);
        }
    }
}
