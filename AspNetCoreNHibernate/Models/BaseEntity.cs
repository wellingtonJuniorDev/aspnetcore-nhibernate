namespace AspNetCoreNHibernate.Models
{
    public abstract class BaseEntity
    {
        public virtual long Id { get; set; }
        public virtual string Name { get; set; }
    }
}
