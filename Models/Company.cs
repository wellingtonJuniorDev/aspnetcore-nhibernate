namespace AspNetCoreNHibernate.Models
{
    public class Company : BaseEntity
    {
        public virtual Supplier Supplier { get; set; }
    }
}
