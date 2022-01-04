namespace AspNetCoreNHibernate.Models
{
    public class Supplier : BaseEntity
    {
        public virtual Company Company { get; set; }
    }
}
