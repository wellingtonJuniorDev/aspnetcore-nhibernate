using System.Collections.Generic;

namespace AspNetCoreNHibernate.Models
{
    public class Category
    {
        public Category()
        {
            Products = new List<Product>();
        }

        public virtual long Id { get; set; }
        public virtual string Name { get; set; }

        public virtual IList<Product> Products { get; set; }
    }
}
