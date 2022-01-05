using AspNetCoreNHibernate.Models.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AspNetCoreNHibernate.Models
{
    public class Product : BaseEntity
    {
        public virtual int Quantity { get; set; }
        public virtual double Price { get; set; }

        public virtual Category Category { get; set; }

        public virtual Audit Audit { get; set; }

        public virtual IList<Supplier> Suppliers { get; set; }

        public virtual void AuditInsertion()
        {
            Audit = new Audit();
        }

        public virtual void AuditUpdate()
        {
            Audit.Updated = DateTime.Now;
        }
        
        public virtual long[] ViewSuppliers { get; set; } // Not mapped

        public virtual void SetSelectedSuppliers() // Not mapped
        {
            Suppliers = ViewSuppliers?.Select(s => new Supplier { Id = s }).ToList();
        }
    }
}