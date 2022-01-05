using AspNetCoreNHibernate.Models;

namespace AspNetCoreNHibernate.Mappings
{
    public class CompanyMap : BaseEntityMapping<Company>
    {
        public CompanyMap()
        {
            Table("Companies");

            References(x => x.Supplier, "SupplierId")
                .Unique()
                .ForeignKey("FK_SupplierCompany");
        }
    }
}
