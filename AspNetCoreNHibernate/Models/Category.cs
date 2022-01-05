using System.Collections.Generic;

namespace AspNetCoreNHibernate.Models
{
    public class Category : BaseEntity
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public virtual IList<Product> Products { get; set; }
    }
}
