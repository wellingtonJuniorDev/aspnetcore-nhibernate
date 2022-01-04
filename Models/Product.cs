using AspNetCoreNHibernate.Models.ValueObjects;
using System;

namespace AspNetCoreNHibernate.Models
{
    public class Product : BaseEntity
    {
        public virtual int Quantity { get; set; }
        public virtual double Price { get; set; }

        public virtual Category Category { get; set; }

        public virtual Audit Audit { get; set; }

        public virtual void AuditInsertion()
        {
            Audit = new Audit();
        }

        public virtual void AuditUpdate()
        {
            Audit.Updated = DateTime.Now;
        }
    }
}