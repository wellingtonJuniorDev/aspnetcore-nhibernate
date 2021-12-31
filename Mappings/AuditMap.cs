using AspNetCoreNHibernate.Models.ValueObjects;
using FluentNHibernate.Mapping;

namespace AspNetCoreNHibernate.Mappings
{
    public class AuditMap : ComponentMap<Audit>
    {
        public AuditMap()
        {
            Map(x => x.Inserted).Not.Nullable().Length(20);

            Map(x => x.Updated).Nullable().Length(20);
        }
    }
}
