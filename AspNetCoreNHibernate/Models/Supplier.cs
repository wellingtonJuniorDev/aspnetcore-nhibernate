using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreNHibernate.Models
{
    public class Supplier : BaseEntity
    {
        public virtual Company Company { get; set; }

        public virtual IList<Product> Products { get; set; }

        public virtual long[] ViewProducts { get; set; } // Not mapped

        public virtual void SetSelectedProducts() // Not mapped
        {
            Products = ViewProducts?.Select(s => new Product { Id = s }).ToList();
        }
    }
}
