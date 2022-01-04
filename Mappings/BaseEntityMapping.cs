using AspNetCoreNHibernate.Models;
using FluentNHibernate.Mapping;

namespace AspNetCoreNHibernate.Mappings
{
    public abstract class BaseEntityMapping<TEntity> : ClassMap<TEntity> where TEntity : BaseEntity
    {
        protected BaseEntityMapping()
        {
            Id(x => x.Id).GeneratedBy.Identity();

            Map(x => x.Name).Not.Nullable().Length(50);
        }
    }
}
